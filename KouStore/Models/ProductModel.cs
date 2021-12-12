using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KouStore.Models
{
    public class ProductModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public StringModel Name { get; set; }
        [Required]
        public StringModel Description { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName ="decimal(10, 2)")]
        [Range(0, 99999)]
        public decimal Price { get; set; }
        [Required]
        public SubCategoryModel Category { get; set; }
        [Required]
        [Range(0,99999)]
        public uint StockQuantity { get; set; }
    }
}
