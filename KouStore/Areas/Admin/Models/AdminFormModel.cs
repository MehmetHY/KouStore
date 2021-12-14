using KouStore.Models;

namespace KouStore.Areas.Admin.Models
{
    public class AdminFormModel
    {
        public AdminModel? Admin { get; set; }
        public bool NameValid { get; set; } = true;
        public bool PasswordValid { get; set; } = true;
        public string? NameErrorMessage { get; set; }
        public string? PasswordErrorMessage { get; set; }
    }
}
