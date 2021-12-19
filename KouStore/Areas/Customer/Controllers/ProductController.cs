using KouStore.Data;
using KouStore.Managers;
using KouStore.Areas.Customer.Models;
using Microsoft.AspNetCore.Mvc;

namespace KouStore.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _db;
        public ProductController(AppDbContext db) { _db = db; }

        [Route("[Controller]/{id}")]
        [HttpGet]
        public IActionResult Index(int id)
        {
            var product = ProductDbManager.GetProduct(id, _db);
            if (product == null) return RedirectToAction("Index", "Home");
            var customer = this.GetCurrentCustomer(_db);
            return View(new ProductPageViewModel(product, customer, customer.HasProduct(product.Id, _db)));
        }

        [Route("[Controller]/[Action]/{id}")]
        [HttpGet]
        public IActionResult AddToCart(int id)
        {
            var customer = this.GetCurrentCustomer(_db);
            if (customer == null)
            {
                return RedirectToAction("Index", "SignIn", new { controllerName = "Product", actionName = nameof(AddToCart), id = id});
            }
            customer.AddToCart(id, _db);
            return RedirectToAction(nameof(Index), new { id = id });
        }
    }
}
