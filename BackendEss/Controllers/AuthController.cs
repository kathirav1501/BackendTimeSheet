using BackendEss.DBContext.Interfaces;
using BackendEss.Dtos.User;
using BackendEss.Model;
using Microsoft.AspNetCore.Mvc;

namespace BackendEss.Controllers
{
    [Route("/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepo;

        public AuthController(IAuthRepository authRepo)
        {
            _authRepo = authRepo;
        }
        [HttpPost("Register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register([FromBody] UserRegisterDto request)
        {
            if (request.RoleID.Equals(null))
            {
                return BadRequest("Role not provided");
            }
            var user = new AppUsers
            {
                UserName = request.Username,
                RoleID = request.RoleID,
                Email = request.Email,
                Active = true
            };
            var projects = request.Projects; // Replace this with the actual list of projects from the request

            var response = await _authRepo.Register(user, request.Password, projects);

            if (!response.IsSucess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }



        [HttpPost("Login")]
        public async Task<ActionResult<ServiceResponse<int>>> Login([FromBody] UserLoginDto request)
        {
            var response = await _authRepo.Login(request.Username, request.Password);
            if (!response.IsSucess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
