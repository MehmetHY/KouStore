using KouStore.Models;

namespace KouStore.Config
{
    public static class Strings
    {
        public enum ErrorMessage
        {
            EmptyAdminName,
            EmptyUserName,
            EmptyPassword,
            WrongAdminName,
            WrongUserName,
            WrongPassword
        }
        public static Dictionary<ErrorMessage, StringModel> ErrorStrings { get; private set; } = new Dictionary<ErrorMessage, StringModel>()
        {
            { ErrorMessage.EmptyAdminName, new StringModel{EnglishString = "Admin name cannot be empty!", TurkishString = "Admin ismi boş bırakılamaz!"} },
            { ErrorMessage.EmptyUserName, new StringModel{EnglishString = "User name cannot be empty!", TurkishString = "Kullanıcı ismi boş bırakılamaz!"} },
            { ErrorMessage.EmptyPassword, new StringModel{EnglishString = "Password cannot be empty!", TurkishString = "Parola boş bırakılamaz!"} },
            { ErrorMessage.WrongAdminName, new StringModel{EnglishString = "Wrong admin name!", TurkishString = "Geçersiz admin ismi!"} },
            { ErrorMessage.WrongUserName, new StringModel{EnglishString = "Wrong user name!", TurkishString = "Geçersiz kullanıcı ismi!"} },
            { ErrorMessage.WrongUserName, new StringModel{EnglishString = "Wrong user password!", TurkishString = "Geçersiz parola!"} }

        };
    }
}
