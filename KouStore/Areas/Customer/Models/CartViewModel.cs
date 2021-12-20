using KouStore.Models;
using KouStore.Managers;
using KouStore.Enums;

namespace KouStore.Areas.Customer.Models
{
    public class CartViewModel
    {
        public CustomerModel? Customer { get; set; }
        public List<ProductModel> Products { get; set; } = new();
        public decimal TotalPrice { 
            get
            {
                decimal total = 0;
                foreach (var product in Products) total += product.Price;
                return total;
            } 
        }
        public PaymentMethod Payment { get; set; }
    }
}
