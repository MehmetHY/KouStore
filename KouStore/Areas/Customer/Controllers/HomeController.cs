using KouStore.Data;
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
        public IActionResult Index([FromQuery] int? pageNumber)
        {
            var model = new HomePageViewModel();
            model.Setup(pageNumber, _db);
            return View(model);
        }
    }
}
