using System.ComponentModel.DataAnnotations;

namespace Administration.Domain.Entities
{
    public class Auth
    {
        [Key]
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string Username { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public int? UserId { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime LastLoginAt { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }

        public Role Role { get; set; } = null!;
    }
}
