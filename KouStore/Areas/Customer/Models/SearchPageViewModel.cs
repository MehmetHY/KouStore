using KouStore.Models.Absracts;
using KouStore.Models;
using KouStore.Managers;
using KouStore.Data;

namespace KouStore.Areas.Customer.Models
{
    public class SearchPageViewModel : QueryPageViewModel<ProductModel>
    {
        public override List<ProductModel> QueryModels { get; set; } = new();
        public string? SearchString { get; set; }
        public string Message { get; set; } = string.Empty;
        public SearchPageViewModel() {}
        public SearchPageViewModel(string? searchString, int? pageNumber, AppDbContext? db) 
        {
            SearchString = searchString;
            if (pageNumber != null) CurrentPage = pageNumber.Value;
            this.LoadSearchProducts(db);
        }
    }
}
