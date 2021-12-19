using Microsoft.AspNetCore.Mvc;
using KouStore.Areas.Customer.Models;
using KouStore.Data;
using KouStore.Managers;

namespace KouStore.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class SearchController : Controller
    {
        private readonly AppDbContext _db;
        public SearchController(AppDbContext db) { _db = db; }

        [Route("[Controller]")]
        [HttpGet]
        public IActionResult Index([FromQuery(Name = "search")] string? searchString)
        {
            return View(new SearchPageViewModel(searchString, _db));
        }
    }
}
