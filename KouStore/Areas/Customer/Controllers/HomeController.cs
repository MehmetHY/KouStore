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
        public IActionResult Index([FromQuery] string? pageNumber)
        {
            var model = new HomePageViewModel();
            if (pageNumber != null) model.CurrentPage = int.Parse(pageNumber);
            model.Categories = CategoryDbManager.GetallCategories(_db);
            int start = (model.CurrentPage - 1) * model.MaxModelSizePerPage;
            model.QueryModels = ProductDbManager.GetProductsRange(_db, start, model.MaxModelSizePerPage, descending: true);
            model.TotalModelCount = ProductDbManager.GetProductCount(_db);
            return View(model);
        }
    }
}
