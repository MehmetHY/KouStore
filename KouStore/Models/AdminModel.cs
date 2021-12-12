using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KouStore.Models
{
    public class AdminModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [DataType(DataType.Text)]
        [DisplayName("Admin Name")]
        public string? UId { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Password)]
        [StringLength(50)]
        public string? Password { get; set; } = string.Empty;
    }
}
