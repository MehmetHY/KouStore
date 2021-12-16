using System.ComponentModel.DataAnnotations;

namespace KouStore.Models
{
    public class CartItem
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public ProductModel Product { get; set; } = new();
    }
}
