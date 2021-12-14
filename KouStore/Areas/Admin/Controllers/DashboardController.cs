using Microsoft.AspNetCore.Mvc;

namespace KouStore.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ManageProducts()
        {
            return View();
        }
        public IActionResult ManageCategories()
        {
            return View();
        }
        public IActionResult ManageCustomers()
        {
            return View();
        }
    }
}
