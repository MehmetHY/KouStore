using KouStore.Models.Interfaces;
using KouStore.Models;
using KouStore.Config;

namespace KouStore.Areas.Customer.Models
{
    public class HomePageViewModel : IQueryPageViewModel<ProductModel>
    {
        public List<ProductModel> QueryModels { get; set; } = new();
        public List<CategoryModel> Categories { get; set; } = new();
        public int MaxModelSizePerPage { get; set; } = Settings.MaxModelSizePerPage;
        public int CurrentPage { get; set; } = 1;
        public int TotalPageCount { get; set; } = 1;
        public int TotalModelCount { get; set; } = 0;
    }
}
