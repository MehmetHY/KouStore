using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KouStore.Models
{
    public class ProductModel
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
        [Required]
        [DataType(DataType.Text)]
        [StringLength(50)]
        public string DescriptionEnglish { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Text)]
        [StringLength(50)]
        public string DescriptionTurkish { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName ="decimal(10, 2)")]
        [Range(0, 99999)]
        public decimal Price { get; set; }
        [Required]
        public SubCategoryModel Category { get; set; } = new SubCategoryModel();
        [Required]
        [Range(0,99999)]
        public uint StockQuantity { get; set; }
        [Required]
        public ImageModel PreviewImage { get; set; } = new ImageModel();
        public List<ImageModel> Images { get; set; } = new List<ImageModel>();
    }
}
