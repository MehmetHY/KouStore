using KouStore.Areas.Admin.Models;
using KouStore.Data;
using KouStore.Models;
using KouStore.Config;

namespace KouStore.Managers
{
    public static class ProductDbManager
    {
        public static void CreateFromViewModel(ProductViewModel productViewModel)
        {
            productViewModel.Product.AddRecord(productViewModel.DbContext);
        }
        public static void AddRecord(this ProductModel? product, AppDbContext? db)
        {
            if (product == null || db == null) return;
            db.Products.Add(product);
            db.SaveChanges();
        }

        public static ProductModel? GetProduct(int? id, AppDbContext? db) =>
            id == null || db == null ? 
            null : db.Products.FirstOrDefault(p => p.Id == id);
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
        public static void LoadProducts(this CategoryModel? category, AppDbContext? db)
        {
            if (category == null || db == null) return;
            category.Products = category.GetProducts(db);
        }
        public static List<ProductModel> GetProductsRange(AppDbContext? db, int start = 0, int count = Settings.MaxModelSizePerPage, bool descending = false) =>
            db == null ? new() :
                descending ?
                    db.Products.OrderByDescending(p => p.Id).Skip(start).Take(count).ToList() :
                    db.Products.Skip(start).Take(count).ToList();
        public static List<ProductModel> GetProductsRange(this CategoryModel? category, AppDbContext? db, int start = 0, int count = Settings.MaxModelSizePerPage, bool descending = false) =>
            db == null || category == null ? new() :
                descending ?
                    db.Products.Where(p => p.CategoryId == category.Id).OrderByDescending(p => p.Id).Skip(start).Take(count).ToList() :
                    db.Products.Where(p => p.CategoryId == category.Id).Skip(start).Take(count).ToList();
        public static int GetProductCount(AppDbContext? db) =>
            db == null ? 0 : db.Products.Count();
        public static int GetProductCount(this CategoryModel category, AppDbContext? db) =>
            category == null || db == null ? 
            0 : db.Products.Where(p => p.CategoryId == category.Id).Count();

        public static void UpdateFromViewModel(ProductViewModel productViewModel)
        {
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
            var query = db.Products.FirstOrDefault(p => p.Id == product.Id);
            if (query == null) return;
            db.Products.Remove(query);
            db.SaveChanges();
            product.DeleteCartItems(db);
        }
        public static void DeleteProducts(this CategoryModel? category, AppDbContext? db)
        {
            if (category == null || db == null) return;
            foreach (var product in db.Products.Where(p => p.CategoryId == category.Id).ToList())
            {
                product.DeleteRecord(db);
            }
        }
    }
}
