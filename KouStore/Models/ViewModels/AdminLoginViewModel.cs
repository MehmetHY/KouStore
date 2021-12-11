using KouStore.Models;
using KouStore.Managers;
namespace KouStore.Models.ViewModels
{
    public class AdminLoginViewModel
    {
        public AdminModel Admin { get; set; }
        public AdminLoginValidation AdminLogin { get; set; }
        public AdminLoginViewModel(AdminModel admin)
        {
            Admin = admin;
        }
    }
}
