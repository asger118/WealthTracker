
using BlazorStockApp.Data.Models;
using BlazorStockApp.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorStockApp.Data.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<StockMeta> StockMeta { get; set; }
        public DbSet<User> Users { get; set; }
    }
}