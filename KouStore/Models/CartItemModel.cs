using System.ComponentModel.DataAnnotations;

namespace KouStore.Models
{
    public class CartItemModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int CustomerId { get; set; }
    }
}
