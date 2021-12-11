using Microsoft.AspNetCore.Mvc;
using KouStore.Models;
using KouStore.Data;

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
            return View(new LoginModel());
        }
        [HttpPost]
        public IActionResult Index(LoginModel model)
        {
            return View(model);
        }

        [HttpPost]
        public IActionResult Verify(LoginModel model)
        {
            (bool, Models.AdminModel?) result = model.IsUIdValid(_db);
            if (!result.Item1 || !model.IsPasswordValid(result.Item2))
            {
                return View(nameof(Index), model);
            }
            HttpContext.Session.SetString("admin", model.UId);
            return Ok(HttpContext.Session.GetString("admin")); 
        }
    }
}
