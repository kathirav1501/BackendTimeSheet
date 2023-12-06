using BackendEss.Dtos.Tasks;

namespace BackendEss.Dtos.User
{
    public class UserTaskDTO
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public ICollection<TaskDTO> Tasks { get; set; }
    }
}
