using KouStore.Managers;

namespace KouStore.Models.ViewModels
{
    public class AdminLoginViewModel
    {
        public AdminModel Admin { get; set; } = new AdminModel();
        public AdminLoginValidation AdminLogin { get; set; } = new AdminLoginValidation();
    }
}
