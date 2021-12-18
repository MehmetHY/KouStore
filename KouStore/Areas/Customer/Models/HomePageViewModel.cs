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
        public int TotalModelCount { get; set; }
        public int CurrentPage { get; set; } = 1;
        public int TotalPageCount
        {
            get
            {
                if (TotalModelCount == 0) return 1;
                int count = TotalModelCount / MaxModelSizePerPage;
                if (TotalModelCount % MaxModelSizePerPage != 0) count++;
                return count;
            }
        }
    }
}
