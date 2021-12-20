using KouStore.Models.Absracts;
using KouStore.Models;
using KouStore.Managers;
using KouStore.Data;

namespace KouStore.Areas.Customer.Models
{
    public class CategoryPageViewModel : QueryPageViewModel<ProductModel>
    {
        public override List<ProductModel> QueryModels { get; set; } = new();
        public CategoryModel? Category { get; set; }
        public CategoryPageViewModel() {}
        public bool Setup(string categoryName, int? pageNumber, AppDbContext db) 
        {
            Category = CategoryDbManager.GetCategory(categoryName, db);
            if (Category == null) return false;
            if (pageNumber != null) CurrentPage = pageNumber.Value;
            int start = (CurrentPage - 1) * MaxModelSizePerPage;
            QueryModels = Category.GetProductsRange(db, start, MaxModelSizePerPage);
            TotalModelCount = Category.GetProductCount(db);
            return true;
        }
    }
}
