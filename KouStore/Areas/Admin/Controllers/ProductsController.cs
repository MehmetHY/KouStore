using KouStore.Areas.Admin.Models;
using KouStore.Data;
using KouStore.Models;
using KouStore.Managers;
using Microsoft.AspNetCore.Mvc;

namespace KouStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly AppDbContext _db;
        public ProductsController(AppDbContext db) { _db = db; }

        [Route("[Area]/{categoryName}/[Controller]/[Action]")]
        [HttpGet]
        public IActionResult Index(string categoryName)
        {   
            CategoryModel? model = _db.GetCategoryByName(categoryName);
            return model == null ?
                RedirectToAction("Index", "Categories").ToAdminAuthAction(this) :
                View(model).ToAdminAuthAction(this);
        }

        [Route("[Area]/{categoryName}/[Controller]/[Action]")]
        [HttpGet]
        public IActionResult Create(string categoryName)
        {
            CategoryModel? model = _db.GetCategoryByName(categoryName);
            
            return model == null ? 
                RedirectToAction("Index", "Categories").ToAdminAuthAction(this) :
                View(new FormModel<ProductViewModel>(new(model))).ToAdminAuthAction(this);
        }
        [HttpPost]
        public IActionResult Create([FromForm] FormModel<ProductViewModel> formModel)
            => formModel.ProcessForm( this,
                                      nameof(Create),
                                      RedirectToAction(nameof(Index), new { categoryName = formModel.ViewModel.Category.Name }),
                                      ProductManager.CreateFromViewModel,
                                      _db );

        [Route("[Area]/{categoryName}/[Controller]/[Action]/{id}")]
        [HttpGet]
        public IActionResult Update(string categoryName, int id)
        {
            return View(new FormModel<ProductViewModel>());
        }
        [HttpPost]
        public IActionResult Update([FromForm] FormModel<ProductViewModel> formModel)
        {
            return View();
        }
        
        [Route("[Area]/{categoryName}/[Controller]/[Action]/{id}")]
        [HttpGet]
        public IActionResult Delete(string categoryName, int id)
        {
            return View(new FormModel<ProductViewModel>());
        }
        [HttpPost]
        public IActionResult Delete([FromForm] FormModel<ProductViewModel> formModel)
        {
            return View();
        }
    }
}
