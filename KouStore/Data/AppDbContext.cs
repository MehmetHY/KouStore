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
        public DbSet<CartItemModel> CartItems { get; set; }
        public DbSet<CartModel> Carts { get; set; }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<CustomerModel> Customers { get; set; }

        public AdminModel? GetAdminByName(string? name) =>
            name == null ? null : Admins.Where(a => a.Name == name).FirstOrDefault();
        public List<ProductModel> AllProducts => Products.ToList();
        public CategoryModel? GetCategoryByName(string? name) =>
            name == null ? null : Categories.Where(c => c.Name == name).FirstOrDefault();

    }
}
