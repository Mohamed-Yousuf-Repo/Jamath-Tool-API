namespace Administration.Domain.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public ICollection<Auth> AuthUsers { get; set; } = new List<Auth>();
    }
}
