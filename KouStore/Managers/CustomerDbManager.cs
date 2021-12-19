using KouStore.Data;
using KouStore.Areas.Customer.Models;
using KouStore.Models;

namespace KouStore.Managers
{
    public static class CustomerDbManager
    {
        public static void CreateFromViewModel(RegisterViewModel registerViewModel)
        {
            registerViewModel.Customer.AddRecord(registerViewModel.DbContext);
            if (registerViewModel.Customer.Id != 0)
            {
                SignInManager.SignInCustomer(registerViewModel.CurrentController!, registerViewModel.Customer);
            }
        }
        public static void AddRecord(this CustomerModel? customer, AppDbContext? db)
        {
            if (customer == null || db == null) return;
            db.Customers.Add(customer);
            db.SaveChanges();
        }

        public static CustomerModel? GetCustomer(int? id, AppDbContext? db) =>
            id == null || db == null ? 
            null : db.Customers.FirstOrDefault(x => x.Id == id);
        public static CustomerModel? GetCustomer(string? name, AppDbContext? db) =>
            name == null || db == null ? 
            null : db.Customers.FirstOrDefault(x => x.Name == name);
        public static bool IsExist(int id, AppDbContext? db) =>
            db!.Customers.Any(c => c.Id == id);
        public static bool IsExist(string name, AppDbContext? db) =>
            db!.Customers.Any(c => c.Name == name);
        public static bool IsExist(this CustomerModel customer, AppDbContext db) =>
            db.Customers.Any(a => a.Id == customer.Id || a.Name == customer.Name);

        public static void UpdateRecord(this CustomerModel? customer, AppDbContext? db)
        {
            if (customer == null || db == null) return;
            var query = db.Customers.First(a => a.Id == customer.Id);
            query.Name = customer.Name;
            query.Password = customer.Password;
            db.SaveChanges();
        }

        public static void DeleteRecord(this CustomerModel? customer, AppDbContext? db)
        {
            if (customer == null || db == null) return;
            customer.DeleteCartItems(db);
            var query = db.Customers.First(a => a.Id == customer.Id || a.Name == customer.Name);
            db.Customers.Remove(query);
            db.SaveChanges();
        }

        public static void FillProperties(this CustomerModel? customer, AppDbContext? db)
        {
            if (customer == null || db == null) return;
            if (customer.Id != 0)
                customer = db.Customers.First(a => a.Id == customer.Id);
            else if (customer.Name != string.Empty)
                customer = db.Customers.First(a => a.Name == customer.Name);
        }
    }
}
