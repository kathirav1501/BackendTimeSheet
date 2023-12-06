using BackendEss.Dtos.Project;
using BackendEss.Model;

namespace BackendEss.Dtos.User
{
    public class UserRegisterDto
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int RoleID { get; set; }

        public List<AddProjectDTO> Projects { get; set; }
    }
}
