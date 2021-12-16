using KouStore.Areas.Admin.Models;
using KouStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace KouStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[Area]/[Controller]/[Action]")]
    public class CategoriesController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(FormModel<CategoryViewModel> formModel)
        {
            return View();
        }

        [HttpGet("{id}")]
        public IActionResult Update(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Update(FormModel<CategoryViewModel> formModel)
        {
            return View();
        }

        [HttpGet("{id}")]
        public IActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Delete(CategoryModel category)
        {
            return View();
        }


    }
}
