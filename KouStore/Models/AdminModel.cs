using System.ComponentModel.DataAnnotations;

namespace KouStore.Models
{
    public class AdminModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Password)]
        [StringLength(100)]
        public string Password { get; set; } = string.Empty;
    }
}
