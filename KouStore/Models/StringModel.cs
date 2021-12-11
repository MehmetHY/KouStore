using KouStore.Config;
using System.ComponentModel.DataAnnotations;

namespace KouStore.Models
{
    public class StringModel
    {
        [Key]
        public int Id { get; set; }
        public string EnglishString { get; set; } = string.Empty;
        public string TurkishString { get; set; } = string.Empty;

        public string Translate()
        {
            switch (Settings.CurrentLanguage)
            {
                case Settings.Language.Turkish:
                    return TurkishString;
                default:
                    return EnglishString;
            }
        }
    }
}
