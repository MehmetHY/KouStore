using KouStore.Data;
using KouStore.Models;

namespace KouStore.Managers
{
    public static class CartItemDbManager
    {
        public static void AddRecord(this CartItemModel? cartItem, AppDbContext? db)
        {
            if (cartItem == null || db == null) return;
            db.CartItems.Add(cartItem);
            db.SaveChanges();
        }

        public static CartItemModel? GetCartItem(int? id, AppDbContext? db) =>
            id == null || db == null ?
                null : db.CartItems.FirstOrDefault(c => c.Id == id);
        public static List<CartItemModel> GetCartItems(this CustomerModel? customer, AppDbContext? db) =>
            customer == null || db == null ?
            new() : db.CartItems.Where(c => c.CustomerId == customer.Id).ToList();

        public static void DeleteRecord(this CartItemModel? cartItem, AppDbContext? db)
        {
            if (cartItem == null || db == null) return;
            var query = db.CartItems.First(c => c.Id == cartItem.Id);
            db.CartItems.Remove(query);
            db.SaveChanges();
        }
        public static void DeleteRecord(int? cartItemId, AppDbContext? db)
        {
            if (cartItemId == null || db == null) return;
            var query = db.CartItems.First(c => c.Id == cartItemId);
            db.CartItems.Remove(query);
            db.SaveChanges();
        }
        public static void DeleteCartItem(this CustomerModel? customer, int? productId, AppDbContext? db)
        {
            if (customer == null || productId == null || db == null) return;
            var query = db.CartItems.FirstOrDefault(c => c.CustomerId == customer.Id && c.ProductId == productId);
            if (query == null) return;
            db.CartItems.Remove(query);
            db.SaveChanges();
        }
        public static void DeleteCartItem(this CustomerModel? customer, ProductModel? product, AppDbContext? db)
        {
            if (customer == null || product == null || db == null) return;
            var query = db.CartItems.FirstOrDefault(c => c.CustomerId == customer.Id && c.ProductId == product.Id);
            if (query == null) return;
            db.CartItems.Remove(query);
            db.SaveChanges();
        }
        public static void DeleteCartItems(this CustomerModel? customer, AppDbContext? db)
        {
            if (customer == null || db == null) return;
            var query = db.CartItems.Where(c => c.CustomerId == customer.Id);
            db.CartItems.RemoveRange(query);
            db.SaveChanges();
        }
        public static void DeleteCartItems(this ProductModel? product, AppDbContext? db)
        {
            if (product == null || db == null) return;
            var query = db.CartItems.Where(c => c.ProductId == product.Id).ToList();
            db.CartItems.RemoveRange(query);
            db.SaveChanges();
        }
    }
}
