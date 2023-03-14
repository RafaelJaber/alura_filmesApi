namespace UserApi.Models
{
    public class User
    {
        public Guid Uid { get; set; } = Guid.NewGuid();
        public string Username { get; set; }
        public string Email { get; set; }
    }
}
