using KouStore.Areas.Admin.Models;
using KouStore.Data;
using KouStore.Models;

namespace KouStore.Managers
{
    public static class ProductManager
    {
        public static void CreateFromViewModel(ProductViewModel model)
        {
            model.Product.AddRecord(model.Category, model.DbContext);
        }
        public static void AddRecord(this ProductModel product, CategoryModel category, AppDbContext db)
        {
            var queryProduct = db.Products.First(p => p.Id == product.Id);
            var queryCategory = db.Categories.First(c => c.Name == category.Name);
            queryCategory.Products.Add(queryProduct);
            db.SaveChanges();
        }
    }
}
