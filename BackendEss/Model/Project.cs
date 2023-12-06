using System.ComponentModel.DataAnnotations;

namespace BackendEss.Model
{
    public class Project : BaseEntity
    {
        [Key]
        public int ProjectID { get; set; }

        [StringLength(100)]
        public string? ProjectName { get; set; } 

       
        
    }
}
