﻿using KouStore.Areas.Admin.Models;
using KouStore.Data;
using KouStore.Models;

namespace KouStore.Managers
{
    public static class CategoryManager
    {
        public static void CreateFromViewModel(CategoryViewModel model)
        {
            model.Category.AddRecord(model.DbContext);
        }
        public static void AddRecord(this CategoryModel model, AppDbContext? db)
        {
            db?.Categories.Add(model);
            db?.SaveChanges();
        }
        public static void UpdateFromViewModel(CategoryViewModel model)
        {
            model.Category.UpdateRecord(model.DbContext);
        }
        public static void UpdateRecord(this CategoryModel model, AppDbContext? db)
        {
            var query = db?.Categories.Where(c => c.Id == model.Id).FirstOrDefault();
            if (query == null) return;
            query.Name = model.Name;
            db?.SaveChanges();
        }
        public static void DeleteRecord(this CategoryModel model, AppDbContext db)
        {
            db.Remove(model);
            db.SaveChanges();
        }
    }
}
