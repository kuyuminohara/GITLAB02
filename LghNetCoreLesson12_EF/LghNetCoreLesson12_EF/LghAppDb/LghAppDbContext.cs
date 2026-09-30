using Microsoft.EntityFrameworkCore;
using LghNetCoreLesson12_EF.Models;
namespace LghNetCoreLesson12_EF.LghAppDb
{
    public class LghAppDbContext : DbContext
    {
        public LghAppDbContext(DbContextOptions<LghAppDbContext> options) : base(options)
        {
        }

        public DbSet<LghCategory> LghCategories { get; set; }
        public DbSet<LghProduct> LghProducts { get; set; }
    }
}   
