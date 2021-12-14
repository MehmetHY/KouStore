using Microsoft.AspNetCore.Mvc;
using KouStore.Managers;

namespace KouStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        [HttpGet]
        [Route("[Area]/[Controller]")]
        public IActionResult Index()
        {
            return SignInManager.GetAdminAuthenticatedAction(View(), this);
        }
        [HttpGet]
        [Route("[Area]/[Controller]/[Action]")]
        public IActionResult ManageProducts()
        {
            return View();
        }
        [HttpGet]
        [Route("[Area]/[Controller]/[Action]")]
        public IActionResult ManageCategories()
        {
            return View();
        }
        [HttpGet]
        [Route("[Area]/[Controller]/[Action]")]
        public IActionResult ManageCustomers()
        {
            return View();
        }
    }
}
