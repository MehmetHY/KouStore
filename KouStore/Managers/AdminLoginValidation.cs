using KouStore.Data;
using KouStore.Models;
using KouStore.Config;

namespace KouStore.Managers
{
    public static class AdminLoginValidation
    {
        public static (bool, string) ValidateLogin(AppDbContext db, AdminModel inputModel)
        {
            string name = inputModel.UId.Trim();
            if (name == "") return (false, Strings.ErrorStrings[Strings.ErrorMessage.EmptyAdminName].GetString());
            string password = inputModel.Password.Trim();
            if (password == "") return (false, Strings.ErrorStrings[Strings.ErrorMessage.EmptyPassword].GetString());
            AdminModel? queryModel = db.Admins.FirstOrDefault(a => a.UId == inputModel.UId);
            if (queryModel == null) return (false, )
            return (true, string.Empty);
        }
    }
}
