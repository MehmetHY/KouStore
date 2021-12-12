using KouStore.Models;

namespace KouStore.Config
{
    public static class Strings
    {
        public enum ErrorMessage
        {
            GeneralLoginError,
            EmptyAdminName,
            EmptyUserName,
            EmptyPassword,
            WrongAdminName,
            WrongUserName,
            WrongPassword,

            EmptyProductName,
            EmptyProductDescription,
            InvalidProductPrice,
            InvalidProductCategory,
            InvalidProductStockQuantity
        }
        public enum Label
        {
            Title,
            English,
            Turkish,
            Description,
            Price,
            Category,
            StockQuantity
        }
        public static Dictionary<ErrorMessage, StringModel> ErrorStrings { get; private set; } = new Dictionary<ErrorMessage, StringModel>()
        {
            { ErrorMessage.GeneralLoginError, new StringModel{EnglishString = "Name or password not correct!", TurkishString = "İsmi ya da parola yanlış!"} },
            { ErrorMessage.EmptyAdminName, new StringModel{EnglishString = "Admin name cannot be empty!", TurkishString = "Admin ismi boş bırakılamaz!"} },
            { ErrorMessage.EmptyUserName, new StringModel{EnglishString = "User name cannot be empty!", TurkishString = "Kullanıcı ismi boş bırakılamaz!"} },
            { ErrorMessage.EmptyPassword, new StringModel{EnglishString = "Password cannot be empty!", TurkishString = "Parola boş bırakılamaz!"} },
            { ErrorMessage.WrongAdminName, new StringModel{EnglishString = "Wrong admin name!", TurkishString = "Geçersiz admin ismi!"} },
            { ErrorMessage.WrongUserName, new StringModel{EnglishString = "Wrong user name!", TurkishString = "Geçersiz kullanıcı ismi!"} },
            { ErrorMessage.WrongPassword, new StringModel{EnglishString = "Wrong user password!", TurkishString = "Geçersiz parola!"} },
            
            { ErrorMessage.EmptyProductName, new StringModel{EnglishString = "Product name cannot be empty!", TurkishString = "Ürün ismi boş bırakılamaz!"} },
            { ErrorMessage.EmptyProductDescription, new StringModel{EnglishString = "Product description cannot be empty!", TurkishString = "Ürün açıklaması boş bırakılamaz!"} },
            { ErrorMessage.InvalidProductPrice, new StringModel{EnglishString = "Invalid product price!", TurkishString = "Geçersiz ürün fiyatı!"} },
            { ErrorMessage.InvalidProductCategory, new StringModel{EnglishString = "Invalid product category!", TurkishString = "Geçersiz ürün kategorisi!"} },
            { ErrorMessage.InvalidProductStockQuantity, new StringModel{EnglishString = "Invalid product stock quantity!", TurkishString = "Geçersiz mevcut stok!"} },

        };

        public static Dictionary<Label, StringModel> LabelStrings { get; private set; } = new Dictionary<Label, StringModel>()
        {
            {Label.Title, new StringModel {EnglishString = "Title", TurkishString="Başlık"} },
            {Label.English, new StringModel {EnglishString = "English", TurkishString="İngilizce"} },
            {Label.Turkish, new StringModel {EnglishString = "Turkish", TurkishString="Türkçe"} },
            {Label.Description, new StringModel {EnglishString = "Description", TurkishString="Açıklama"} },
            {Label.Price, new StringModel {EnglishString = "Price", TurkishString="Fiyat"} },
            {Label.Category, new StringModel {EnglishString = "Category", TurkishString="Kategori"} },
            {Label.StockQuantity, new StringModel {EnglishString = "Stock Quantity", TurkishString="Stok Adedi"} }
        };
    }
}
