using Microsoft.AspNetCore.Mvc;
using KouStore.Managers;
using KouStore.Data;

namespace KouStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly AppDbContext _db;
        public DashboardController(AppDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        [Route("[Area]/[Controller]")]
        public IActionResult Index()
        {
            return SignInManager.ConvertActionToAdminAuthenticatedAction(View(), this);
        }
        [HttpGet]
        [Route("[Area]/[Controller]/[Action]")]
        public IActionResult ManageProducts() 
            => SignInManager.ConvertActionToAdminAuthenticatedAction(View(_db.AllProducts), this);
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
