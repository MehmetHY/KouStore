using KouStore.Areas.Admin.Models;
using KouStore.Data;
using KouStore.Managers;
using KouStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace KouStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SignInController : Controller
    {
        private readonly AppDbContext _db;
        public SignInController(AppDbContext db) { _db = db; }

        [Route("[Area]/[Controller]")]
        [HttpGet]
        public IActionResult Index()
        {
            if (SignInManager.IsAdminSignedIn(HttpContext.Session))
                return RedirectToAction("Index", "Dashboard");
            return View(new FormModel<AdminViewModel>());
        }

        [HttpPost]
        public IActionResult Index(FormModel<AdminViewModel> formModel)
        {
            formModel.Setup( this, 
                             nameof(Index), 
                             RedirectToAction("Index", "Dashboard"), 
                             SignInManager.SignInAdmin, 
                             _db );
            return formModel.ProcessForm();
        }

        [HttpGet]
        [Route("[Area]/[Controller]/[Action]")]
        public IActionResult Logout()
        {
            SignInManager.LogOutAdmin(HttpContext.Session);
            return RedirectToAction(nameof(Index));
        }
    }
}
