using KouStore.Areas.Admin.Models;
using KouStore.Data;
using KouStore.Managers;
using Microsoft.AspNetCore.Mvc;

namespace KouStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SignInController : Controller
    {
        private readonly AppDbContext _db;
        public SignInController(AppDbContext db)
        {
            _db = db;
        }

        [Route("[Area]/[Controller]")]
        [HttpGet]
        public IActionResult Index()
        {
            if (SignInManager.IsAdminSignedIn(HttpContext.Session))
            {
                // Todo: Redirect to Dashboard
                return Ok($"Dashboard Admin id: {HttpContext.Session.GetString(SignInManager.ADMIN_ID_KEY)}");
            }
            return View(new AdminFormModel());
        }
        [HttpPost]
        public IActionResult Index(AdminFormModel model)
        {
            if (model.IsFormValid(_db))
            {
                // Todo: Redirect to Dashboard
                SignInManager.SignInAdmin(HttpContext.Session, model.Admin);
                return Ok($"Dashboard. Admin Name: {model.Admin.Name}, Id = {model.Admin.Id}");
            }
            return View(model);
        }
    }
}
