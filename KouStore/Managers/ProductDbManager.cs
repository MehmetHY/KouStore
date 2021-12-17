using KouStore.Areas.Admin.Models;
using KouStore.Data;
using KouStore.Models;

namespace KouStore.Managers
{
    public static class ProductDbManager
    {
        public static void CreateFromViewModel(ProductViewModel model)
        {
            model.Product.AddRecord(model.DbContext);
        }
        public static void AddRecord(this ProductModel product, AppDbContext db)
        {
            db.Products.Add(product);
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
        
        public static List<ProductModel> GetProductsInCart(this CustomerModel customer, AppDbContext db)
        {
            List<CartItemModel> cartItems = db.CartItems.Where(c => c.CustomerId == customer.Id).ToList();
            List<ProductModel> products = new List<ProductModel>();
            foreach (var cartItem in cartItems)
            {
                ProductModel product = db.Products.First(p => p.Id == cartItem.ProductId);
                products.Add(product);
            }
            return products;
        }

        public static List<ProductModel> GetProductsInCategory(this CategoryModel category, AppDbContext db) =>
            db.Products.Where(p => p.CategoryId == category.Id).ToList();
    }
}
