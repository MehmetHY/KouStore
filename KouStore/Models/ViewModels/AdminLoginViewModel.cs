using KouStore.Managers;

namespace KouStore.Models.ViewModels
{
    public class AdminLoginViewModel
    {
        public AdminModel Admin { get; set; }
        public AdminLoginValidation AdminLogin { get; set; }
    }
}
