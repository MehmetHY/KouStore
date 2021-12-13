using System.ComponentModel.DataAnnotations;

namespace KouStore.Models
{
    public class CategoryModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [StringLength(50)]
        public string NameEnglish { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Text)]
        [StringLength(50)]
        public string NameTurkish { get; set; } = string.Empty;

        public StringModel GetNameStringModel()
        {
            return new StringModel { EnglishString = NameEnglish, TurkishString = NameTurkish };
        }
    }
}
