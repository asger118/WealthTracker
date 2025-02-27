
using BlazorStockApp.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorStockApp.Data.Contexts
{
    public class StockDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<StockMeta> StockMeta { get; set; }
    }
}
