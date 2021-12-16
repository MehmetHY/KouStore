using KouStore.Areas.Admin.Models;
using KouStore.Data;
using KouStore.Models;
using KouStore.Managers;
using Microsoft.AspNetCore.Mvc;

namespace KouStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[Area]/[Controller]/[Action]")]
    public class CategoriesController : Controller
    {
        private readonly AppDbContext _db;
        public CategoriesController(AppDbContext db) { _db = db; }
        
        [HttpGet]
        public IActionResult Index() => 
            View(_db.AllCategories).ToAdminAuthAction(this);

        [HttpGet]
        public IActionResult Create() =>
            View(new FormModel<CategoryViewModel>()).ToAdminAuthAction(this);

        [HttpPost]
        public IActionResult Create(FormModel<CategoryViewModel> formModel) =>
            formModel.ProcessForm( this,
                                   nameof(Create),
                                   RedirectToAction(nameof(Index)),
                                   CategoryManager.CreateFromViewModel,
                                   _db );

        [HttpGet("{id}")]
        public IActionResult Update(int id) =>
            View(_db.GetCategoryById(id)).ToAdminAuthAction(this);

        [HttpPost]
        public IActionResult Update(FormModel<CategoryViewModel> formModel) =>
            formModel.ProcessForm( this,
                                    nameof(Update),
                                    RedirectToAction(nameof(Index)),
                                    CategoryManager.UpdateFromViewModel,
                                    _db );

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
