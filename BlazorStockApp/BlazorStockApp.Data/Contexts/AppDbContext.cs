
using BlazorStockApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorStockApp.Data.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserStock> UserStocks { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<RegularTradingPeriod> RegularTradingPeriods { get; set; }
    }
}

// Create migration
// dotnet ef migrations add 0001-initial --project BlazorStockApp.Data --startup-project BlazorStockApp/BlazorStockApp
// Update database with migration
// dotnet ef database update --project BlazorStockApp.Data --startup-project BlazorStockApp/BlazorStockApp
