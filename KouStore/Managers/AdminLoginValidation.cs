using KouStore.Data;
using KouStore.Models;
using KouStore.Managers;
using static KouStore.Config.Strings;
using static KouStore.Config.Strings.ErrorMessage;

namespace KouStore.Managers
{
    public class AdminLoginValidation
    {
        public string NameErrorMessage { get; set; } = string.Empty;
        public bool NameValid = true;
        public string PasswordErrorMessage { get; set; } = string.Empty;
        public bool PasswordValid = true;
        public bool ValidateLogin(AppDbContext db, AdminModel model)
        {
            bool isEmpty = false;
            if (string.IsNullOrEmpty(model.UId))
            {
                NameValid = false;
                NameErrorMessage = ErrorStrings[EmptyAdminName].Translate();
                isEmpty = true;
            }
            if (string.IsNullOrEmpty(model.Password))
            {
                PasswordValid = false;
                PasswordErrorMessage = ErrorStrings[EmptyPassword].Translate();
                isEmpty = true;
            }
            if (isEmpty) return false;
            AdminModel? queryModel = db.GetAdminByName(model.UId);
            if (queryModel == null)
            {
                NameValid = false;
                NameErrorMessage = ErrorStrings[WrongAdminName].Translate();
            }
            else if (queryModel.Password != model.Password)
            {
                PasswordValid = false;
                PasswordErrorMessage = ErrorStrings[WrongPassword].Translate();
            }
            bool result = NameValid && PasswordValid;
            return result;
        }
    }
}
