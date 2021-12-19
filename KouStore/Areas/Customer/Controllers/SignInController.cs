using KouStore.Data;
using KouStore.Managers;
using KouStore.Models;
using Microsoft.AspNetCore.Mvc;
using KouStore.Areas.Customer.Models;

namespace KouStore.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class SignInController : Controller
    {
        private readonly AppDbContext _db;
        public SignInController(AppDbContext db) { _db = db; }

        public IActionResult Index()
        {
            var homePage = RedirectToAction("Index", "Home");
            return this.IsCustomerSignedIn() ? homePage : 
                View(new FormModel<SignInViewModel>{ TargetActionResult = homePage });
        }
    }
}
