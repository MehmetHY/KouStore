using Microsoft.AspNetCore.Mvc;
using KouStore.Models;
using KouStore.Data;

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
        public IActionResult Index()
        {
            return View(new LoginModel());
        }

        [HttpPost]
        public IActionResult Verify(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            return View(nameof(Index)); 
        }

    }
}
