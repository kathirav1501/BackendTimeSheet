using System.ComponentModel.DataAnnotations;

namespace BackendEss.Model
{
    public class Tasks : BaseEntity
    {
        [Key]
        public int TaskID { get; set; }

        [MaxLength]
        public string? TaskName { get; set; }

        [MaxLength]
        public string? Description { get; set; }

        [StringLength(50)]
        public string? JiraID { get; set; }

        [MaxLength]
        public string? JiraLink { get; set; }

        public int? ProjectID { get; set; }
        public Project? Project { get; set; }

        public int? UserID { get; set; }
        public AppUsers? User { get; set; }

        public DateTime? TaskStartTime { get; set; }
        public DateTime? TaskEndTime { get; set; }

        public float HoursSpent { get; set; }
    }
}
