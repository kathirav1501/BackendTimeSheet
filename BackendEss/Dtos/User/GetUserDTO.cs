using BackendEss.Dtos.Project;
using BackendEss.Model;

namespace BackendEss.Dtos.User
{
    public class GetUserDTO
    {

        public int UserID { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool? Active { get; set; }
        public List<ProjectDTO> Projects { get; set; } 
        public Role Role { get; set; }

    }
}
