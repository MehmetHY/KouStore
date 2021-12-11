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
    }
}
