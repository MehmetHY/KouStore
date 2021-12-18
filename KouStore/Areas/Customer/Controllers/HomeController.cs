using KouStore.Data;
using KouStore.Managers;
using KouStore.Areas.Customer.Models;
using Microsoft.AspNetCore.Mvc;

namespace KouStore.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly AppDbContext _db;
        public HomeController(AppDbContext db) { _db = db; }

        [HttpGet]
        public IActionResult Index() =>
            View(new HomePageViewModel()
            {
                Categories = CategoryDbManager.GetallCategories(_db),
                QueryModels = ProductDbManager.GetProductsRange(_db, descending: true),
                TotalModelCount = ProductDbManager.GetProductCount(_db)
            });
    }
}
