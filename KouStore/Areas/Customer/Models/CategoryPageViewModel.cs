using KouStore.Models.Absracts;
using KouStore.Models;

namespace KouStore.Areas.Customer.Models
{
    public class CategoryPageViewModel : QueryPageViewModel<ProductModel>
    {
        public override List<ProductModel> QueryModels { get; set; } = new();
        public CategoryModel Category { get; set; } = new();
    }
}
