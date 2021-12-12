using Microsoft.AspNetCore.Mvc;
using KouStore.Managers;
using KouStore.Models;
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

        [Route("[area]/[controller]/[action]/{id}")]
        [HttpGet]
        public IActionResult Index([FromRoute] int id)
        {
            bool isAuthorized = AdminLoginManager.IsAuthorized(HttpContext.Session, id);
            if (!isAuthorized)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
        [Route("[area]/[controller]/[action]")]
        [HttpGet]
        public IActionResult Logout()
        {
            AdminLoginManager.Logout(HttpContext.Session);
            return RedirectToAction("Index", "Login");
        }
        [Route("[area]/[controller]/[action]")]
        [HttpGet]
        public IActionResult ManageProducts()
        {
            if (!AdminLoginManager.IsLoggedIn(HttpContext.Session))
            {
                return RedirectToAction("Index", "Login");
            }
            List<ProductModel> products = _db.GetAllProducts();
            return View(products);
        }
    }
}
