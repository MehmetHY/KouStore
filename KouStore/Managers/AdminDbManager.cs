using KouStore.Data;
using KouStore.Models;

namespace KouStore.Managers
{
    public static class AdminDbManager
    {
        public static void AddRecord(this AdminModel? admin, AppDbContext? db)
        {
            if (admin == null || db == null) return;
            db.Admins.Add(admin);
            db.SaveChanges();
        }

        public static AdminModel? GetById(int? id, AppDbContext? db) =>
            id == null || db == null ? null: db.Admins.FirstOrDefault(a => a.Id == id);
        public static AdminModel? GetByName(string? name, AppDbContext? db) =>
            name == null || db == null ? null : db.Admins.FirstOrDefault(a => a.Name == name);

        public static void UpdateRecord(this AdminModel? admin, AppDbContext? db)
        {
            if (admin == null || db == null) return;
            var query = db.Admins.First(a => a.Id == admin.Id);
            query.Name = admin.Name;
            query.Password = admin.Password;
            db.SaveChanges();
        }

        public static void DeleteRecord(this AdminModel? admin, AppDbContext? db)
        {
            if (admin == null || db == null) return;
            var query = db.Admins.First(a => a.Id == admin.Id || a.Name == admin.Name);
            db.Admins.Remove(query);
            db.SaveChanges();
        }

        public static void FillProperties(this AdminModel? admin, AppDbContext? db)
        {
            if (admin == null || db == null) return;
            if (admin.Id != 0)
                admin = db.Admins.First(a =>a.Id == admin.Id);
            else if (admin.Name != string.Empty)
                admin = db.Admins.First(a => a.Name == admin.Name);
        }
        public static bool IsExist(this AdminModel admin, AppDbContext db) =>
            db.Admins.Any(a => a.Id == admin.Id || a.Name == admin.Name);
    }
}
