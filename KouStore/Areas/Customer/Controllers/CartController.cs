using Microsoft.AspNetCore.Mvc;

namespace KouStore.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class CartController : Controller
    {
        [Route("[Controller]/{id}")]
        [HttpGet]
        public IActionResult Index(int id)
        {
            return View();
        }
    }
}
