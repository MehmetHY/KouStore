namespace KouStore.Models
{
    public class SubCategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CategoryModel Category { get; set; }
    }
}
