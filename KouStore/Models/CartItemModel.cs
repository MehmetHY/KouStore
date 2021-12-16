using System.ComponentModel.DataAnnotations;

namespace KouStore.Models
{
    public class CartItemModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public ProductModel Product { get; set; } = new();
    }
}
