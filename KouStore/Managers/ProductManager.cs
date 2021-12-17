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
            var queryCategory = db.Categories.First(c => c.Name == category.Name);
            queryCategory.Products.Add(product);
            db.SaveChanges();
        }

        public static void UpdateFromViewModel(ProductViewModel model)
        {
            model.Product.UpdateRecord(model.DbContext);
        }
        public static void UpdateRecord(this ProductModel product, AppDbContext db)
        {
            var queryModel = db.Products.First(p => p.Id == product.Id);
            queryModel.Title = product.Title;
            queryModel.Description = product.Description;
            queryModel.Image = product.Image;
            queryModel.Price = product.Price;
            db.SaveChanges();
        }

        public static void DeleteRecord(this ProductModel product, AppDbContext db)
        {
            db.Products.Remove(product);
            db.SaveChanges();
        }
    }
}
