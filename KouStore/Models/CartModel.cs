using System.ComponentModel.DataAnnotations;

namespace KouStore.Models
{
    public class CartModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public List<CartItemModel> CartItems { get; set; } = new List<CartItemModel>();
    }
}
