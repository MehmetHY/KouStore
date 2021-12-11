using Microsoft.AspNetCore.Mvc;
using KouStore.Models;
using KouStore.Data;
using KouStore.Managers;

namespace KouStore.Areas.Admin.Controllers
{
    [Area("admin")]
    public class LoginController : Controller
    {
        private readonly AppDbContext _db;
        public LoginController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new AdminModel());
        }
        [HttpPost]
        public IActionResult Index(string error)
        {
            ViewData["Error"] = error;
            return View(new AdminModel());
        }
        [HttpPost]
        public IActionResult Verify(AdminModel? model)
        {
            return Ok();
        }
    }
}
