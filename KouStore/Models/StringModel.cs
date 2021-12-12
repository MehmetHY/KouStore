using KouStore.Config;
using System.ComponentModel.DataAnnotations;

namespace KouStore.Models
{
    public class StringModel
    {
        [Required]
        [DataType(DataType.Text)]
        public string EnglishString { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string TurkishString { get; set; }

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
