using KouStore.Areas.Admin.Models;
using KouStore.Data;
using KouStore.Models;

namespace KouStore.Managers
{
    public static class CategoryManager
    {
        public static void CreateFromViewModel(CategoryViewModel model)
        {
            model.Category.AddToDb(model.DbContext);
        }
        public static void AddToDb(this CategoryModel model, AppDbContext? db)
        {
            db?.Categories.Add(model);
        }
    }
}
