using KouStore.Data;
using KouStore.Managers;
using Microsoft.AspNetCore.Mvc;

namespace KouStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CustomersController : Controller
    {
        private readonly AppDbContext _db;
        public CustomersController(AppDbContext db) { _db = db; }

        [Route("[Area]/[Controller]")]
        [Route("[Area]/[Controller]/[Action]")]
        [HttpGet]
        public IActionResult Index()
        {
            return View(_db.Customers.ToList()).ToAdminAuthAction(this);
        }

        [Route("[Area]/[Controller]/[Action]/{id}")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (!this.IsAdminSignedIn())
                RedirectToAction("Index", "SignIn");
            var customer = CustomerDbManager.GetCustomer(id, _db);
            if (customer != null)
                customer.DeleteRecord(_db);
            return RedirectToAction(nameof(Index)).ToAdminAuthAction(this);
        }
    }
}
