using System.ComponentModel.DataAnnotations;

namespace BackendEss.Model
{
    public class UserProject : BaseEntity
    {
        [Key]
        public int UserProjectID { get; set; }

        public int? UserID { get; set; }
        public AppUsers? User { get; set; }

        public int? ProjectID { get; set; }
        public Project? Project { get; set; }
    }
}
