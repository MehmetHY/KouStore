using KouStore.Data;
using KouStore.Models;
using static KouStore.Config.Strings;
using static KouStore.Config.Strings.ErrorMessage;

namespace KouStore.Managers
{
    public class AdminLoginValidation
    {
        private readonly AdminModel _adminModel;
        private readonly AppDbContext _db;
        public string NameErrorMessage { get; set; } = string.Empty;
        private bool _nameValid = true;
        public string PasswordErrorMessage { get; set; } = string.Empty;
        private bool _passwordValid = true;
        public AdminLoginValidation(AppDbContext db, AdminModel model)
        {
            _db = db;
            _adminModel = model;
        }
        public bool ValidateLogin()
        {
            bool isEmpty = false;
            if (string.IsNullOrEmpty(_adminModel.UId))
            {
                _nameValid = false;
                NameErrorMessage = ErrorStrings[EmptyAdminName].Translate();
                isEmpty = true;
            }
            if (string.IsNullOrEmpty(_adminModel.Password))
            {
                _passwordValid = false;
                PasswordErrorMessage = ErrorStrings[EmptyPassword].Translate();
                isEmpty = true;
            }
            if (isEmpty) return false;
            AdminModel? queryModel = _db.Admins.FirstOrDefault(a => a.UId == _adminModel.UId);
            if (queryModel == null)
            {
                _nameValid = false;
                NameErrorMessage = ErrorStrings[WrongAdminName].Translate();
            }
            else if (queryModel.Password != _adminModel.Password)
            {
                _passwordValid = false;
                PasswordErrorMessage = ErrorStrings[WrongPassword].Translate();
            }
            return _nameValid && _passwordValid;
        }
    }
}
