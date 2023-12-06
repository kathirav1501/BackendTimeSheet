using System.ComponentModel.DataAnnotations;

namespace BackendEss.Model
{
    public class AppUsers : BaseEntity
    {
        [Key]
        public int UserID { get; set; }

        [StringLength(50)]
        public string UserName { get; set; } = string.Empty;

        [StringLength(100)]
        public string Email { get; set; } = string.Empty;

        public bool? Active { get; set; }

        public int? RoleID { get; set; }
        public Role? Role { get; set; } 

        public byte[] PasswordHash { get; set; } = Array.Empty<byte>();

        public byte[] PasswordSalt { get; set; } = Array.Empty<byte>();

        public ICollection<UserProject> UserProjects { get; set; }

        public ICollection<Tasks> Tasks { get; set; }
    }
}
