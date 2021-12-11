using Microsoft.AspNetCore.Mvc;

namespace KouStore.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        [Area("admin")]
        public IActionResult Index()
        {
            string title = "There";
            return View((object)title);
        }
    }
}
