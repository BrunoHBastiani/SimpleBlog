namespace SimpleBlog.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public ICollection<Post>? Posts { get; set; } = null;

        public User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }
    }
}
