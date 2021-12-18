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
            CategoryModel? model = CategoryDbManager.GetCategory(categoryName, _db);
            model?.LoadProducts(_db);
            return model == null ?
                RedirectToAction("Index", "Categories").ToAdminAuthAction(this) :
                View(model).ToAdminAuthAction(this);
        }

        [Route("[Area]/{categoryName}/[Controller]/[Action]")]
        [HttpGet]
        public IActionResult Create(string categoryName)
        {
            CategoryModel? model = CategoryDbManager.GetCategory(categoryName, _db);
            return model == null ? 
                RedirectToAction("Index", "Categories").ToAdminAuthAction(this) :
                View(new FormModel<ProductViewModel>(new(model))).ToAdminAuthAction(this);
        }
        [Route("[Area]/{categoryName}/[Controller]/[Action]/{formModel}")]
        [HttpPost]
        [RequestSizeLimit(100000000)]
        public IActionResult Create([FromForm] FormModel<ProductViewModel> formModel)
            => formModel.ProcessForm( this,
                                      nameof(Create),
                                      RedirectToAction(nameof(Index), new { categoryName = formModel.ViewModel.Category.Name }),
                                      ProductDbManager.CreateFromViewModel,
                                      _db );

        [Route("[Area]/{categoryName}/[Controller]/[Action]/{id}")]
        [HttpGet]
        public IActionResult Update(string categoryName, int id)
        {
            CategoryModel? category = CategoryDbManager.GetCategory(categoryName, _db);
            ProductModel? product = ProductDbManager.GetProduct(id, _db);
            return category == null || product == null ?
                RedirectToAction(nameof(Index), new { categoryName = categoryName })
                    .ToAdminAuthAction(this) 
                :
                View(new FormModel<ProductViewModel>(new(category, product)))
                    .ToAdminAuthAction(this);
        }
        [Route("[Area]/[Controller]/[Action]/{formModel}")]
        [HttpPost]
        [RequestSizeLimit(100000000)]
        public IActionResult Update([FromForm] FormModel<ProductViewModel> formModel) =>
            formModel.ProcessForm( this,
                                   nameof(Update),
                                   RedirectToAction(nameof(Index), new { categoryName = formModel.ViewModel.Category.Name }),
                                   ProductDbManager.UpdateFromViewModel,
                                   _db );
        
        [Route("[Area]/{categoryName}/[Controller]/[Action]/{id}")]
        [HttpGet]
        public IActionResult Delete(string categoryName, int id)
        {
            CategoryModel? category = CategoryDbManager.GetCategory(categoryName, _db);
            ProductModel? product = ProductDbManager.GetProduct(id, _db);
            return category == null || product == null ?
                RedirectToAction(nameof(Index), new { categoryName = categoryName })
                    .ToAdminAuthAction(this)
                :
                Delete(category, product).ToAdminAuthAction(this);
        }
        [HttpPost]
        public IActionResult Delete(CategoryModel category, ProductModel product)
        {
            if (this.IsAdminSignedIn())
                product.DeleteRecord(_db);
            return RedirectToAction(nameof(Index), new { categoryName = category.Name }).ToAdminAuthAction(this);
        }
    }
}
