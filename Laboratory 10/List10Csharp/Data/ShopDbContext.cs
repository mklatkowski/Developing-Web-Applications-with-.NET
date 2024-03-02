using List10Csharp.Models;
using Microsoft.EntityFrameworkCore;

namespace List10Csharp.Data
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
