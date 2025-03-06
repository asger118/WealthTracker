using WealthTracker.Contexts;

namespace WealthTracker.Models.Data
{
    public static class SeedData
    {
        public static async Task SeedSectorsAsync(AppDbContext context)
        {
            if (!context.Sectors.Any())
            {
                await context.Sectors.AddRangeAsync(
                    new Sector { SectorName = "Energy", SectorDescription = "Companies involved in oil, gas, coal, and renewable energy" },
                    new Sector { SectorName = "Materials", SectorDescription = "Companies producing chemicals, construction materials, metals, and paper products" },
                    new Sector { SectorName = "Industrials", SectorDescription = "Includes aerospace, defense, transportation, and manufacturing companies" },
                    new Sector { SectorName = "Consumer Discretionary", SectorDescription = "Non-essential goods and services (e.g., retail, luxury, entertainment, automobiles)" },
                    new Sector { SectorName = "Consumer Staples", SectorDescription = "Essential goods like food, beverages, and household products" },
                    new Sector { SectorName = "Healthcare", SectorDescription = "Includes pharmaceuticals, biotech, and health services" },
                    new Sector { SectorName = "Finance", SectorDescription = "Banks, insurance companies, and investment firms" },
                    new Sector { SectorName = "Technology", SectorDescription = "Tech companies, software, hardware, and semiconductors" },
                    new Sector { SectorName = "Communication Services", SectorDescription = "Telecom, media, and digital platforms" },
                    new Sector { SectorName = "Utilities", SectorDescription = "Electricity, gas, and water providers" },
                    new Sector { SectorName = "Real Estate", SectorDescription = "REITs (Real Estate Investment Trusts) and property developers" }
                );

                await context.SaveChangesAsync();
            }
        }

        public static async Task SeedAssetTypesAsync(AppDbContext context)
        {
            if (!context.AssetTypes.Any())
            {
                await context.AssetTypes.AddRangeAsync(
                    new AssetType { Name = "Index Fund", Description = "A type of mutual fund that passively tracks a market index, offering low-cost, diversified exposure to the stock market" },
                    new AssetType { Name = "Active Fund", Description = "A mutual fund where professional managers actively select stocks and other assets in an attempt to outperform the market" },
                    new AssetType { Name = "Single Stock", Description = "Ownership in a specific company, offering potential for high returns but with higher risk compared to diversified investments" },
                    new AssetType { Name = "ETF", Description = "An Exchange-Traded Fund that holds a basket of assets and trades on stock exchanges, offering low-cost, diversified exposure with flexibility" }
                );

                await context.SaveChangesAsync();
            }
        }
    }
}