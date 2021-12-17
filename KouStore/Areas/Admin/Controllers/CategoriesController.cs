using KouStore.Areas.Admin.Models;
using KouStore.Data;
using KouStore.Models;
using KouStore.Managers;
using Microsoft.AspNetCore.Mvc;

namespace KouStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly AppDbContext _db;
        public CategoriesController(AppDbContext db) { _db = db; }

        [Route("[Area]/[Controller]")]
        [Route("[Area]/[Controller]/[Action]")]
        [HttpGet]
        public IActionResult Index() => 
            View(_db.AllCategories).ToAdminAuthAction(this);

        [Route("[Area]/[Controller]/[Action]")]
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
        [Route("[Area]/[Controller]/[Action]/{id}")]
        [HttpGet]
        public IActionResult Update(int id)
        {
            CategoryModel? model = _db.GetCategoryById(id);
            return model == null ?
                RedirectToAction(nameof(Index)) :
                View(new FormModel<CategoryViewModel>(new(model))).ToAdminAuthAction(this);
        }

        [Route("[Area]/[Controller]/[Action]/{formModel}")]
        [HttpPost]
        public IActionResult Update([FromForm] FormModel<CategoryViewModel> formModel) =>
            formModel.ProcessForm( 
                this,
                nameof(Update),
                RedirectToAction(nameof(Index)),
                CategoryManager.UpdateFromViewModel,
                _db );

        [Route("[Area]/[Controller]/[Action]/{id}")]
        [HttpGet]
        public IActionResult Delete(int id) =>
            Delete(_db.GetCategoryById(id)).ToAdminAuthAction(this);

        [HttpPost]
        public IActionResult Delete(CategoryModel? model)
        {
            if (this.IsAdminSignedIn()) model?.DeleteRecord(_db);
            return RedirectToAction(nameof(Index));
        }
    }
}
