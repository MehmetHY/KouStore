using KouStore.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace KouStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SignInController : Controller
    {
        [Route("[Area]/[Controller]")]
        [HttpGet]
        public IActionResult Index()
        {
            return View(new AdminFormModel());
        }
        [Route("[Area]/[Controller]")]
        [HttpGet]
        public IActionResult Index(AdminFormModel? model)
        {
            return View(model);
        }
    }
}
