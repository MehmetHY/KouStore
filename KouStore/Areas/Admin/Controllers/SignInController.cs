using KouStore.Areas.Admin.Models;
using KouStore.Data;
using KouStore.Managers;
using Microsoft.AspNetCore.Mvc;

namespace KouStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SignInController : Controller
    {
        private readonly AppDbContext _db;
        public SignInController(AppDbContext db)
        {
            _db = db;
        }

        [Route("[Area]/[Controller]")]
        [HttpGet]
        public IActionResult Index()
        {
            if (SignInManager.IsAdminSignedIn(HttpContext.Session))
            {
                return RedirectToAction("Index", "Dashboard");
            }
            return View(new AdminFormModel());
        }
        [HttpPost]
        public IActionResult Index(AdminFormModel model)
        {
            if (model.IsFormValid(_db))
            {
                SignInManager.SignInAdmin(HttpContext.Session, model.Admin);
                return RedirectToAction("Index", "Dashboard");
            }
            return View(model);
        }
        [HttpGet]
        [Route("[Area]/[Controller]/[Action]")]
        public IActionResult Logout()
        {
            if (SignInManager.IsAdminSignedIn(HttpContext.Session))
            {
                SignInManager.LogOutAdmin(HttpContext.Session);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
