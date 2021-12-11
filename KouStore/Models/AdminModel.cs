using System.ComponentModel.DataAnnotations;

namespace KouStore.Models
{
    public class AdminModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        [DataType(DataType.Text)]
        public string? UId { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Password)]
        [StringLength(50)]
        public string? Password { get; set; } = string.Empty;
    }
}
