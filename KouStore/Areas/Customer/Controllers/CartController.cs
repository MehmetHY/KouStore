using Microsoft.AspNetCore.Mvc;
using KouStore.Areas.Customer.Models;
using KouStore.Managers;
using KouStore.Data;

namespace KouStore.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class CartController : Controller
    {
        private readonly AppDbContext _db;
        public CartController(AppDbContext db) { _db = db; }

        [Route("[Controller]/{id}")]
        [HttpGet]
        public IActionResult Index(int id)
        {
            var customer = this.GetCurrentCustomer(_db);
            if (customer == null)
            {
                return RedirectToAction("Index", "SignIn", new { controllerName = "Cart", actionName = nameof(Index), id = id });
            }
            var model = new CartViewModel
            {
                Customer = customer,
                Products = customer.GetProducts(_db)
            };
            return View(model);
        }

        [Route("[Action]")]
        [HttpPost]
        public IActionResult Checkout(CartViewModel cartModel)
        {
            return View(cartModel);
        }
        
        [Route("[Action]")]
        [HttpPost]
        public IActionResult Payment(CartViewModel cartModel)
        {
            return View(cartModel);
        }
    }
}
