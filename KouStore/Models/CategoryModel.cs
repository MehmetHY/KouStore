using System.ComponentModel.DataAnnotations;

namespace KouStore.Models
{
    public class CategoryModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public StringModel Name { get; set; }
    }
}
