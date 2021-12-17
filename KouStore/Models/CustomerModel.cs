using System.ComponentModel.DataAnnotations;
using KouStore.Data;
using KouStore.Managers;

namespace KouStore.Models
{
    public class CustomerModel
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
