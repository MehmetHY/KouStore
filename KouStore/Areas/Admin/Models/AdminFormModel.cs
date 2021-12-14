using KouStore.Data;
using KouStore.Models;

namespace KouStore.Areas.Admin.Models
{
    public class AdminFormModel
    {
        public AdminModel Admin { get; set; } = new();
        public bool NameValid { get; set; } = true;
        public bool PasswordValid { get; set; } = true;
        public string NameErrorMessage { get; set; } = "";
        public string PasswordErrorMessage { get; set; } = "";

        private void TrimWhiteSpace()
        {
            Admin.Name = (Admin.Name ?? "").Trim();
            Admin.Password = (Admin.Password ?? "").Trim();
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
        private bool AreNameAndPasswordCorrect(AppDbContext db)
        {
            AdminModel? queryModel = db.GetAdminByName(Admin.Name);
            if (queryModel == null)
            {
                NameErrorMessage = $"Admin name {Admin.Name} doesn't exists!";
                NameValid = false;
                return false;
            }
            if (queryModel.Password != Admin.Password)
            {
                PasswordErrorMessage = "Wrong password!";
                PasswordValid = false;
                return false;
            }
            return true;
        }
        private void ValidateForm(AppDbContext db)
        {
            TrimWhiteSpace();
            if (IsThereAnyEmptyForm()) return;
            if (!AreNameAndPasswordCorrect(db)) return;
        }
        private bool GetFinalResult() => NameValid && PasswordValid;
        public bool IsFormValid(AppDbContext db)
        {
            ValidateForm(db);
            return GetFinalResult();
        }
    }
}
