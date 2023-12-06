using BackendEss.DBContext.Interfaces;
using BackendEss.Dtos.Auth;
using BackendEss.Dtos.Project;
using BackendEss.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BackendEss.DBContext.Implimentation
{
    public class AuthRepository : IAuthRepository
    {
        private readonly EssDBContext _context;
        private readonly IConfiguration _configuration;
        public AuthRepository(EssDBContext context, IConfiguration configuration)
        {
            _configuration = configuration;
            _context = context;

        }
        public async Task<ServiceResponse<AuthDTO>> Login(string username, string password)
        {
            var response = new ServiceResponse<AuthDTO>();

            try
            {
                var user = await _context.AppUsers.Include(u => u.Role)
                    .FirstOrDefaultAsync(u => u.UserName.ToLower().Equals(username.ToLower()));

                if (user == null)
                {
                    response.IsSucess = false;
                    response.Message = "User not found.";
                }
                else if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                {
                    response.IsSucess = false;
                    response.Message = "Wrong password.";
                }
                else
                {
                    response.Data = new AuthDTO(); // Ensure response.Data is initialized

                    // Check if user.Role is not null before accessing its properties
                    if (user.Role != null)
                    {
                        response.Data.AccessToken = CreateToken(user);
                        response.Data.Role = user.Role.RoleName;
                        response.Data.UserID = user.UserID;
                        
                    }
                    else
                    {
                        // Handle the case where user.Role is null
                        response.IsSucess = false;
                        response.Message = "Role information not found for the user.";
                    }

                    response.IsSucess = true;
                    response.Message = "Welcome";
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, log the error, or set appropriate response values
                response.IsSucess = false;
                response.Message = "An error occurred during login.";
                // Log the exception: logger.LogError(ex, "Error during login");
            }

            return response;
        }


        public async Task<ServiceResponse<int>> Register(AppUsers appUsers, string password , List<AddProjectDTO> projects)
        { 
            var response = new ServiceResponse<int>();
            try
            {

                if (await UserExist(appUsers.UserName))
                {
                    response.IsSucess = false;
                    response.Message = "User already exists.";
                    return response;
                }

                CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

                appUsers.PasswordHash = passwordHash;
                appUsers.PasswordSalt = passwordSalt;

                await _context.AppUsers.AddAsync(appUsers);
                await _context.SaveChangesAsync();

                // Associate the user with the provided projects
                foreach (var project in projects)
                {
                    var userProject = new UserProject
                    {
                        UserID = appUsers.UserID, 
                        ProjectID = project.ProjectId 
                    };

                    // Save the association to the database
                    await _context.UserProject.AddAsync(userProject);
                }
                await _context.SaveChangesAsync();
                response.Data = appUsers.UserID;
                response.IsSucess = true;
                response.Message = "Created";

            }
            catch (DbUpdateException)
            {
                response.Data = appUsers.UserID;
                response.IsSucess = false;
                response.Message = $"Invalid RoleId: {appUsers.RoleID} Provided";

            }
            catch (Exception)
            {

                throw new Exception();
            }

            return response;
        }

        public async Task<bool> UserExist(string username)
        {
            if (await _context.AppUsers.AnyAsync(u => u.UserName.ToLower() == username.ToLower()))
            {
                return true;
            }
            return false;
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new System.Security.Cryptography.HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }

        private static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt);
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(passwordHash);
        }

        private string CreateToken(AppUsers user)
        {
            var userRole = _context.Roles.FirstOrDefault(r => r.RoleID == user.RoleID);

            var claims = new List<Claim>
            {
                new (ClaimTypes.NameIdentifier, user.UserID.ToString()),
                new (ClaimTypes.Name, user.UserName),
                new (ClaimTypes.Role, userRole.RoleName.ToString())
            };

            var appSettingsToken = _configuration.GetSection("AppSettings:Token").Value 
                ?? throw new Exception("AppSettings Token is null!");

            SymmetricSecurityKey key = new (System.Text.Encoding.UTF8
                .GetBytes(appSettingsToken));

            SigningCredentials creds = new (key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            JwtSecurityTokenHandler tokenHandler = new ();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
