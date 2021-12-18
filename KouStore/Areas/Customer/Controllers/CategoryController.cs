using KouStore.Data;
using KouStore.Managers;
using KouStore.Areas.Customer.Models;
using Microsoft.AspNetCore.Mvc;

namespace KouStore.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _db;
        public CategoryController(AppDbContext db) { _db = db; }

        [Route("[Controller]/{categoryName}")]
        [HttpGet]
        public IActionResult Index(string categoryName)
        {
            var category = CategoryDbManager.GetCategory(categoryName, _db);
            if (category == null) return RedirectToAction("Index", "Home");
            return View(new CategoryPageViewModel()
            {
                Category = category,
                QueryModels = category.GetProductsRange(_db),
                TotalModelCount = category.GetProductCount(_db)
            }) ;
        }
    }
}
