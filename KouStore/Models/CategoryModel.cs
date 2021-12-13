using System.ComponentModel.DataAnnotations;

namespace KouStore.Models
{
    public class CategoryModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [StringLength(50)]
        public string? Name { get; set; } = null;
    }
}
