using Microsoft.AspNetCore.Mvc;
using KouStore.Models;
using KouStore.Data;
using KouStore.Models.ViewModels;

namespace KouStore.Areas.Admin.Controllers
{
    [Area("admin")]
    public class LoginController : Controller
    {
        private readonly AppDbContext _db;
        public LoginController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new AdminLoginViewModel() { Admin = new AdminModel(), AdminLogin = new Managers.AdminLoginValidation() });
        }
        [HttpPost]
        public IActionResult Index(AdminLoginViewModel model)
        {
            return View(model);
        }
        [HttpPost]
        public IActionResult Verify(AdminLoginViewModel model)
        {
            model.AdminLogin = new Managers.AdminLoginValidation();
            if (!model.AdminLogin.ValidateLogin(_db, model.Admin))
            {
                return View(nameof(Index), model);
            }
            return Ok("OK");
        }
    }
}
