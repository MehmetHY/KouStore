using System.ComponentModel.DataAnnotations;

namespace KouStore.Models
{
    public class AdminModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UId { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
