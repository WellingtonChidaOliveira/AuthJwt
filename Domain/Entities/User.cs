namespace Domain.Entities
{
    public class User
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Roles { get; set; }
    }
}
