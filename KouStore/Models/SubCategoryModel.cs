using System.ComponentModel.DataAnnotations;

namespace KouStore.Models
{
    public class SubCategoryModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [Required]
        public CategoryModel Category { get; set; }
    }
}
