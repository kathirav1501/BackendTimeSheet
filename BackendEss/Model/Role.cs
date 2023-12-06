using System.ComponentModel.DataAnnotations;

namespace BackendEss.Model
{
    public class Role
    {
        [Key]
        public int RoleID { get; set; }

        [StringLength(50)]
        public string RoleName { get; set; } = string.Empty;
    }
}
