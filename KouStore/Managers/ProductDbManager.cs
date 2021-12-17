using KouStore.Areas.Admin.Models;
using KouStore.Data;
using KouStore.Models;

namespace KouStore.Managers
{
    public static class ProductDbManager
    {
        public static void CreateFromViewModel(ProductViewModel productViewModel)
        {
            if (productViewModel.DbContext != null)
                productViewModel.Product.AddRecord(productViewModel.DbContext);
        }
        public static void AddRecord(this ProductModel? product, AppDbContext? db)
        {
            if (product == null || db == null) return;
            db.Products.Add(product);
            db.SaveChanges();
        }

        public static List<ProductModel> GetProducts(this CustomerModel? customer, AppDbContext? db)
        {
            if (customer == null || db == null) return new();
            List<CartItemModel> cartItems = customer.GetCartItems(db);
            List<ProductModel> products = new List<ProductModel>();
            foreach (var cartItem in cartItems)
            {
                ProductModel product = db.Products.First(p => p.Id == cartItem.ProductId);
                products.Add(product);
            }
            return products;
        }
        public static List<ProductModel> GetProducts(this CategoryModel? category, AppDbContext? db) =>
            category == null || db == null ? 
            new() :
            db.Products.Where(p => p.CategoryId == category.Id).ToList();

        public static void UpdateFromViewModel(ProductViewModel productViewModel)
        {
            if (productViewModel.DbContext != null)
                productViewModel.Product.UpdateRecord(productViewModel.DbContext);
        }
        public static void UpdateRecord(this ProductModel? product, AppDbContext? db)
        {
            if (product == null || db == null) return;
            var queryModel = db.Products.First(p => p.Id == product.Id);
            queryModel.Title = product.Title;
            queryModel.Description = product.Description;
            queryModel.Image = product.Image;
            queryModel.Price = product.Price;
            db.SaveChanges();
        }

        public static void DeleteRecord(this ProductModel? product, AppDbContext? db)
        {
            if (product == null || db == null) return;
            product.DeleteCartItems(db);
            var query = db.Products.First(p => p.Id == product.Id);
            db.Products.Remove(query);
            db.SaveChanges();
        }
        public static void DeleteProducts(this CategoryModel? category, AppDbContext? db)
        {
            if (category == null || db == null) return;
            foreach (var product in db.Products.Where(p => p.CategoryId == category.Id))
            {
                product.DeleteRecord(db);
            }
        }
    }
}
