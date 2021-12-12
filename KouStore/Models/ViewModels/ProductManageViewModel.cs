using KouStore.Data;

namespace KouStore.Models.ViewModels
{
    public class ProductManageViewModel
    {
        public ProductModel Product { get; set; }
        public List<CategoryModel> Categories { get; set; }
        public List<SubCategoryModel> SubCategories { get; set; }
        public ProductManageViewModel ProductValidate { get; set; }
        public int SubCategoryId { get; set; }
        public ProductManageViewModel(AppDbContext db)
        {
            Categories = db.GetAllCategories();
            SubCategories = db.GetAllSubCategories();
        }
    }
}
