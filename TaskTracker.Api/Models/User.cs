namespace TaskTracker.Api.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!; //Note: It suppresses nullable reference type warnings. This property will not be null at runtime.
        public string PasswordHash { get; set; } = null!;
    }
}
