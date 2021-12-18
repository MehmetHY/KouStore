using KouStore.Models.Absracts;
using KouStore.Models;
using KouStore.Config;

namespace KouStore.Areas.Customer.Models
{
    public class CategoryPageViewModel : QueryPageViewModel<ProductModel>
    {
        public override List<ProductModel> QueryModels { get; set; } = new();
    }
}
