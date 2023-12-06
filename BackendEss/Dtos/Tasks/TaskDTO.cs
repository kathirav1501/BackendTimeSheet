using BackendEss.Dtos.Project;

namespace BackendEss.Dtos.Tasks
{
    public class TaskDTO
    {
        public int TaskID { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
        public string JiraID { get; set; }
        public string JiraLink { get; set; }
        public DateTime? Date { get; set; }

        public float HoursSpent { get; set; }   
        public ProjectDTO Project { get; set; } = null;
    }
}
