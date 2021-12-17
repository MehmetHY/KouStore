﻿using KouStore.Data;
using KouStore.Models;

namespace KouStore.Managers
{
    public static class AdminDbManager
    {
        public static void AddRecord(this AdminModel admin, AppDbContext db)
        {
            db.Admins.Add(admin);
            db.SaveChanges();
        }
        public static void UpdateRecord(this AdminModel admin, AppDbContext db)
        {
            var query = db.Admins.First(a => a.Id == admin.Id);
            query.Name = admin.Name;
            query.Password = admin.Password;
            db.SaveChanges();
        }
        public static void DeleteRecord(this AdminModel admin, AppDbContext db)
        {
            var query = db.Admins.First(a => a.Id == admin.Id);
            db.Admins.Remove(query);
            db.SaveChanges();
        }
        public static void FillProperties(this AdminModel admin, AppDbContext db)
        {
            if (admin.Id != 0)
                admin = db.Admins.First(a =>a.Id == admin.Id);
            else if (admin.Name != string.Empty)
                admin = db.Admins.First(a => a.Name == admin.Name);
        }
        public static bool IsExist(this AdminModel admin, AppDbContext db)
        {
            return db.Admins.Any(a => a.Name == admin.Name) || db.Admins.Any(a => a.Id == admin.Id);
        }
    }
}
