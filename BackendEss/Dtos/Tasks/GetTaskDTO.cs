using BackendEss.Dtos.User;

namespace BackendEss.Dtos.Tasks
{
    public class GetTaskDTO
    {
        public string TaskName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string JiraID { get; set; } = string.Empty;
        public string JiraLink { get; set; } = string.Empty;
        public int ProjectID { get; set; }

        public GetUserDTO getUserDTO { get; set; }

        public DateTime TaskStartTime { get; set; }
        public DateTime TaskEndTime { get; set; }
    }
}
