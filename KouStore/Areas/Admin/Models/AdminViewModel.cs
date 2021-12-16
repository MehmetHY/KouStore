using KouStore.Data;
using KouStore.Models;
using KouStore.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KouStore.Areas.Admin.Models
{
    public class AdminViewModel : IViewModel
    {
        public AdminModel Admin { get; set; } = new();
        public bool NameValid { get; set; } = true;
        public bool PasswordValid { get; set; } = true;
        public string NameErrorMessage { get; set; } = string.Empty;
        public string PasswordErrorMessage { get; set; } = string.Empty;
        public AppDbContext? DbContext { get; set; }
        public ISession? Session { get; set; }
        public bool Result => NameValid && PasswordValid;
        public void Setup(AppDbContext db, Controller controller)
        {
            DbContext = db;
            Session = controller.HttpContext.Session;
        }
        public void ValidateViewModel()
        {
            TrimWhiteSpace();
            if (IsThereAnyEmptyForm()) return;
            if (!AreNameAndPasswordCorrect()) return;
        }
        private void TrimWhiteSpace()
        {
            Admin.Name = (Admin.Name ?? string.Empty).Trim();
            Admin.Password = (Admin.Password ?? string.Empty).Trim();
        }
        private bool IsThereAnyEmptyForm()
        {
            bool result = false;
            if (string.IsNullOrWhiteSpace(Admin.Name))
            {
                NameValid = false;
                NameErrorMessage = "Admin name cannot be empty!";
                result = true;
            }
            if (string.IsNullOrWhiteSpace(Admin.Password))
            {
                PasswordValid = false;
                PasswordErrorMessage = "Password cannot be empty!";
                result = true;
            }
            return result;
        }
        private bool AreNameAndPasswordCorrect()
        {
            AdminModel? queryModel = DbContext.GetAdminByName(Admin.Name);
            if (queryModel == null)
            {
                NameErrorMessage = $"Admin name \"{Admin.Name}\" doesn't exists!";
                NameValid = false;
                return false;
            }
            if (queryModel.Password != Admin.Password)
            {
                PasswordErrorMessage = "Wrong password!";
                PasswordValid = false;
                return false;
            }
            Admin.Id = queryModel.Id;
            return true;
        }
    }
}
