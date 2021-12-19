using KouStore.Models.Absracts;
using KouStore.Models;

namespace KouStore.Areas.Customer.Models
{
    public class SearchPageViewModel : QueryPageViewModel<ProductModel>
    {
        public override List<ProductModel> QueryModels { get; set; } = new();
    }
}
