using System.ComponentModel.DataAnnotations;

namespace KouStore.Models
{
    public class SubCategoryModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public StringModel Name { get; set; }
        [Required]
        public CategoryModel Category { get; set; }
    }
}
