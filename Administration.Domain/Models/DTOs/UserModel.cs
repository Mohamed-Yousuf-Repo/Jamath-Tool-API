namespace Administration.Domain.Models.DTOs
{
    public class UserModel
    {
        public Guid? UserId { get; set; }
        public string Username { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Role { get; set; } = null!;
    }
}
