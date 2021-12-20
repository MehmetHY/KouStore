using KouStore.Models;
using KouStore.Enums;

namespace KouStore.Areas.Customer.Models
{
    public class CartViewModel
    {
        public CustomerModel? Customer { get; set; }
        public decimal TotalPrice { get; set; }
        public PaymentMethod Payment { get; set; }
    }
}
