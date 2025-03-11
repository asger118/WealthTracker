using WealthTracker.Models;
using Microsoft.EntityFrameworkCore;
using WealthTracker.Models.Data;

namespace WealthTracker.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        // User-related DbSets
        public DbSet<User> Users { get; set; }
        public DbSet<UserStock> UserStocks { get; set; }
        
        // Asset-related DbSets
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<AssetType> AssetTypes { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        
        // Trading-related DbSet
        public DbSet<RegularTradingPeriod> RegularTradingPeriods { get; set; }
    }
}


// dotnet ef migrations add <migration name>

// dotnet ef database update

// dotnet ef database drop