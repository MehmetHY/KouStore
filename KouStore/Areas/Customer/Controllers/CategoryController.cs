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
        public IActionResult Index(string categoryName, [FromQuery] int? pageNumber)
        {
            var model = new CategoryPageViewModel();
            return model.Setup(categoryName, pageNumber, _db) ?
                View(model) : RedirectToAction("Index", "Home");
        }
    }
}
