using KouStore.Areas.Admin.Models;
using KouStore.Data;
using KouStore.Models;

namespace KouStore.Managers
{
    public static class CategoryDbManager
    {
        public static void CreateFromViewModel(CategoryViewModel categoryViewModel)
        {
            if (categoryViewModel.DbContext != null)
                categoryViewModel.Category.AddRecord(categoryViewModel.DbContext);
        }
        public static void AddRecord(this CategoryModel? category, AppDbContext? db)
        {
            if (category == null || db == null) return;
            db.Categories.Add(category);
            db.SaveChanges();
        }

        public static CategoryModel? GetCategory(int? id, AppDbContext? db) =>
            id == null || db == null ? 
            null : db.Categories.FirstOrDefault(c => c.Id == id);
        public static CategoryModel? GetCategory(string? name, AppDbContext? db) =>
            name == null || db == null ? 
            null : db.Categories.FirstOrDefault(c => c.Name == name);
        public static CategoryModel? GetCategory(this ProductModel? product, AppDbContext? db) =>
            product == null || db == null ? 
            null : db.Categories.FirstOrDefault(c => c.Id == product.CategoryId);

        public static void UpdateFromViewModel(CategoryViewModel categoryViewModel)
        {
            if (categoryViewModel.DbContext != null)
                categoryViewModel.Category.UpdateRecord(categoryViewModel.DbContext);
        }
        public static void UpdateRecord(this CategoryModel? category, AppDbContext? db)
        {
            if (category == null || db == null) return;
            var query = db.Categories.First(c => c.Id == category.Id);
            query.Name = category.Name;
            db.SaveChanges();
        }

        public static void DeleteRecord(this CategoryModel? category, AppDbContext? db)
        {
            if (category == null || db == null) return;
            category.DeleteProducts(db);
            var query = db.Categories.First(c => c.Id == category.Id || c.Name == category.Name);
            db.Categories.Remove(query);
            db.SaveChanges();
        }

        public static void FillProperties(this CategoryModel? category, AppDbContext? db)
        {
            if (category == null || db == null) return;
            if (category.Id != 0)
                category = db.Categories.First(c => c.Id == category.Id);
            else if (category.Name != string.Empty)
                category = db.Categories.First(c => c.Name == category.Name);
        }
        public static bool IsExist(this CategoryModel category, AppDbContext db) =>
            db.Categories.Any(c => c.Id == category.Id || c.Name == category.Name);
    }
}
