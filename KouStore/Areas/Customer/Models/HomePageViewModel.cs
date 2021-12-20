using KouStore.Models.Absracts;
using KouStore.Models;
using KouStore.Data;
using KouStore.Managers;

namespace KouStore.Areas.Customer.Models
{
    public class HomePageViewModel : QueryPageViewModel<ProductModel>
    {
        public override List<ProductModel> QueryModels { get; set; } = new();
        public List<CategoryModel> Categories { get; set; } = new();

        public void Setup(int? pageNumber, AppDbContext db)
        {
            if (pageNumber != null) CurrentPage = pageNumber.Value;
            Categories = CategoryDbManager.GetallCategories(db);
            int start = (CurrentPage - 1) * MaxModelSizePerPage;
            QueryModels = ProductDbManager.GetProductsRange(db, start, MaxModelSizePerPage, descending: true);
            TotalModelCount = ProductDbManager.GetProductCount(db);
        }
    }
}
