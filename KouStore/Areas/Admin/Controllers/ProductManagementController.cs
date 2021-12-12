using KouStore.Data;
using KouStore.Managers;
using Microsoft.AspNetCore.Mvc;

namespace KouStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductManagementController : Controller
    {
        private readonly AppDbContext _db;
        public ProductManagementController(AppDbContext db)
        {
            _db = db;
        }
        [Route("[area]/[controller]/[action]")]
        [HttpGet]
        public IActionResult Index()
        {
            if (!AdminLoginManager.IsLoggedIn(HttpContext.Session))
            {
                return RedirectToAction("Index", "Login");
            }
            return View(_db.GetAllProducts());
        }
    }
}
