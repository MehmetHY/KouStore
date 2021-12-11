namespace KouStore.Models
{
    public class LoginModel
    {
        public string UId { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string CorrectPassword { get; set; } = string.Empty;
    }
}
