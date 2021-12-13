using System.ComponentModel.DataAnnotations;

namespace KouStore.Models
{
    public class CostumerModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [StringLength(50)]
        public string? Name { get; set; } = null;
        [Required]
        [DataType(DataType.Password)]
        [StringLength(100)]
        public string? Password { get; set; } = null;
    }
}
