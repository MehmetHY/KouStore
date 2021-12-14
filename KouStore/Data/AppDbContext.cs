using Microsoft.EntityFrameworkCore;
using KouStore.Models;

namespace KouStore.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<AdminModel> Admins { get; set; }
        public DbSet<CustomerModel> Customers { get; set; }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<CategoryModel> Categorys { get; set; }

        public AdminModel? GetAdminByName(string? name)
        {
            if (name == null) return null;
            return Admins.Where(a => a.Name == name).FirstOrDefault();
        }
    }
}
