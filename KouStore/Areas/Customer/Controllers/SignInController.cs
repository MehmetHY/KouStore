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

        [Route("[Controller]")]
        [HttpGet]
        public IActionResult Index()
        {
            var homePage = RedirectToAction("Index", "Home");
            return this.IsCustomerSignedIn() ? homePage : 
                View(new FormModel<SignInViewModel>{ TargetActionResult = homePage });
        }
        
        [Route("[Controller]")]
        [HttpPost]
        public IActionResult Index([FromRoute(Name = "targetAction")] IActionResult targetAction) =>
            this.IsCustomerSignedIn() ? targetAction : 
                View(new FormModel<SignInViewModel>{ TargetActionResult = targetAction });

        [HttpPost]
        public IActionResult Index([FromForm] FormModel<SignInViewModel> formModel) =>
            formModel.ProcessForm( this,
                                   nameof(Index),
                                   formModel.TargetActionResult!,
                                   SignInManager.SignInCustomer,
                                   _db );

        [Route("[Action]")]
        [HttpGet]
        public IActionResult Register() =>
            View
            (
                new FormModel<RegisterViewModel>
                { 
                    TargetActionResult = RedirectToAction("Index", "Home") 
                }
            );

        [Route("[Action]")]
        [HttpPost]
        public IActionResult Register([FromRoute(Name = "targetAction")] IActionResult targetAction) =>
            View
            (
                new FormModel<RegisterViewModel>
                { 
                    TargetActionResult = targetAction
                }
            );
        
        [HttpPost]
        public IActionResult Register([FromForm] FormModel<RegisterViewModel> formModel) =>
            formModel.ProcessForm( this,
                                   nameof(Register),
                                   formModel.TargetActionResult!,
                                   CustomerDbManager.CreateFromViewModel,
                                   _db );
    }
}
