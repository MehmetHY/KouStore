using Microsoft.AspNetCore.Mvc;
using KouStore.Managers;
using KouStore.Data;

namespace KouStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly AppDbContext _db;
        public DashboardController(AppDbContext db) { _db = db; }

        [HttpGet]
        [Route("[Area]/[Controller]")]
        public IActionResult Index() =>
            View().ToAdminAuthAction(this);

        [HttpGet]
        [Route("[Area]/[Controller]/[Action]")]
        public IActionResult ManageProducts() => 
            View(_db.AllProducts).ToAdminAuthAction(this);

        [HttpGet]
        [Route("[Area]/[Controller]/[Action]")]
        public IActionResult ManageCategories() =>
            View().ToAdminAuthAction(this);

        [HttpGet]
        [Route("[Area]/[Controller]/[Action]")]
        public IActionResult ManageCustomers() =>
            View().ToAdminAuthAction(this);
    }
}
