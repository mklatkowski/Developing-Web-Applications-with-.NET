using System.Collections.Generic;
using Lab11Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab11Project.Data
{
    public class RP_ShopDbContext : DbContext
    {
        public RP_ShopDbContext(DbContextOptions<RP_ShopDbContext> options) : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
