using Microsoft.AspNetCore.Mvc;
using KouStore.Models;

namespace KouStore.Areas.Admin.Controllers
{
    [Area("admin")]
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View(new LoginModel());
        }

        [HttpPost]
        public IActionResult Verify(LoginModel model)
        {
            if (model == null)
            {
                return View("Index");
            }
            return RedirectToAction("Index", "Dashboard");
        }

    }
}
