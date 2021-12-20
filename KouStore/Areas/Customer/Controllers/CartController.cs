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
        public IActionResult Checkout([FromForm] CartViewModel cartModel)
        {
            cartModel.Products = cartModel.Customer.GetProducts(_db);
            return View(cartModel);
        }
        
        [Route("[Action]")]
        [HttpPost]
        public IActionResult Payment([FromForm] CartViewModel cartModel)
        {
            cartModel.Products = cartModel.Customer.GetProducts(_db);
            return View(cartModel);
        }

        [Route("[Action]")]
        [HttpGet]
        public IActionResult Remove([FromQuery] int id)
        {
            var product = ProductDbManager.GetProduct(id, _db);
            if (product == null) 
                return RedirectToAction("Index", "Home");
            var customer = this.GetCurrentCustomer(_db);
            if (customer == null)
                return RedirectToAction("Index", "SignIn", new { controllerName = "Cart", actionName = nameof(Remove), id = id });
            customer.DeleteCartItem(id, _db);
            return RedirectToAction(nameof(Index), new { id });
        }
    }
}
