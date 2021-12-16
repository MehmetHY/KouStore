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
        public IActionResult Index() =>
            this.IsAdminSignedIn() ?
                RedirectToAction("Index", "Dashboard") :
                View(new FormModel<AdminViewModel>());

        [HttpPost]
        public IActionResult Index(FormModel<AdminViewModel> formModel) =>
            formModel.ProcessForm( this,
                                   nameof(Index),
                                   RedirectToAction("Index", "Dashboard"),
                                   SignInManager.SignInAdmin,
                                   _db );

        [HttpGet]
        [Route("[Area]/[Action]")]
        public IActionResult Logout()
        {
            this.LogOutAdmin();
            return RedirectToAction(nameof(Index));
        }
    }
}
