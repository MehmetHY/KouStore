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
        
        [Route("[Controller]/[Action]/{controllerName}/{actionName}/{id}")]
        [HttpGet]
        public IActionResult Index([FromRoute(Name = "controllerName")] string controllerName, [FromRoute(Name = "actionName")] string actionName, [FromRoute(Name = "id")] int id)
        {
            ViewBag.LastAction = actionName;
            ViewBag.LastController = controllerName;
            ViewBag.LastId = id;
            return View(new FormModel<SignInViewModel>());
        }

        [Route("[Controller]/[Action]/{tController}/{tAction}/{tId}")]
        [HttpPost]
        public IActionResult ValidateSignIn([FromForm] FormModel<SignInViewModel> formModel, [FromRoute] string tController, [FromRoute] string tAction, [FromRoute] int tId)
        {
            var target = RedirectToAction(tAction, tController, new { id = tId });
            return formModel.ProcessForm( this,
                                   nameof(Index),
                                   target,
                                   SignInManager.SignInCustomer,
                                   _db );
        }

        [Route("[Action]")]
        [HttpGet]
        public IActionResult Register() => View(new FormModel<RegisterViewModel>());
        
        [HttpPost]
        public IActionResult ValidateRegister(FormModel<RegisterViewModel> formModel) =>
            formModel.ProcessForm( this,
                                   nameof(Register),
                                   RedirectToAction("Index", "Home"),
                                   CustomerDbManager.CreateFromViewModel,
                                   _db );
    }
}
