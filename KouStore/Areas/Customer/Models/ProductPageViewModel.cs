using KouStore.Models;

namespace KouStore.Areas.Customer.Models
{
    public class ProductPageViewModel
    {
        public ProductModel Product { get; set; }
        public CustomerModel? Customer { get; set; }
        public bool IsInCard { get; set; } = false;
        public ProductPageViewModel(ProductModel product, CustomerModel? customer = null, bool isInCard = false)
        {
            Product = product;
            Customer = customer;
            IsInCard = isInCard;
        }
    }
}
