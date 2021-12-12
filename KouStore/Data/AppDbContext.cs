using KouStore.Models;
using Microsoft.EntityFrameworkCore;

namespace KouStore.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<AdminModel> Admins { get; set; }
        public AdminModel? GetAdminByName(string name)
        {
            return Admins.FirstOrDefault(a => a.UId == name);
        }

        public DbSet<ProductModel> Products { get; set; }
        public List<ProductModel> GetAllProducts()
        {
            return Products.ToList();
        }
        public ProductModel? GetProductById(int id)
        {
            return Products.FirstOrDefault(p => p.Id == id);
        }

        public DbSet<CategoryModel> Categories { get; set; }
        public List<CategoryModel> GetAllCategories()
        {
            return Categories.ToList();
        }
        
        public DbSet<SubCategoryModel> SubCategories { get; set; }
        public List<SubCategoryModel> GetAllSubCategories()
        {
            return SubCategories.ToList();
        }
    }
}
