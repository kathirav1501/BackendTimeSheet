namespace BackendEss.Dtos.Tasks
{
    public class AddTaskDTO
    {
        public string TaskName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string JiraID { get; set; } = string.Empty;
        public string JiraLink { get; set; } = string.Empty;
        public int ProjectID { get; set; }

        public int UserID { get; set; }

        public DateTime Date { get; set; }
        public long HoursSpent { get; set; }
    }
}
