using System.ComponentModel.DataAnnotations;
using static KouStore.Config.Settings;

namespace KouStore.Models
{
    public class ProductModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [StringLength(50)]
        public string? Title { get; set; } = null;
        [Required]
        [DataType(DataType.Text)]
        public string Description { get; set; } = "";
        [Required]
        public byte[]? Image { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int PriceFraction { get; set; }
    }
}
