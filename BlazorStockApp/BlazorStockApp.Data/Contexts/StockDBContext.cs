
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
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<StockMeta> StockMeta { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserStock> UserStocks { get; set; }
    }
}

// Create migration
// dotnet ef migrations add 0001-initial --project BlazorStockApp.Data --startup-project BlazorStockApp/BlazorStockApp
// Update database with migration
// dotnet ef database update --project BlazorStockApp.Data --startup-project BlazorStockApp/BlazorStockApp
