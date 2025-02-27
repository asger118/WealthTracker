
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorStockApp.Shared.Models
{
    public class StockMeta
    {
        [Key]
        public string Ticker { get; set; } = string.Empty; // Stock Ticker Symbol (e.g., AAPL)
        public string Name { get; set; } = string.Empty; // Full Name of the Stock (e.g., Apple Inc.)
        public string Currency { get; set; } = string.Empty; // Currency (e.g., USD)
        public string ExchangeName { get; set; } = string.Empty; // The exchange name (e.g., NASDAQ)
        public string[] ValidHistoricalDataRange { get; set; } = []; // valid ranges for graph
        public int FirstTradeDate { get; set; } // Can be used to calculate age of stock/company
        [ForeignKey("SectorId")]
        public int SectorId {  get; set; } 
        public string? IconType { get; set; }
        public byte[]? Icon { get; set; }
    }
    // "Index Fund", "Single Stock, "ETF",
    public class Sector
    {
        [Key]
        public int SectorId { get; set; }
        public string SectorName { get; set; }// Name of the sector (e.g., "Technology", "Healthcare", "Energy", "Oil & Gas", "Finance")
    }
}
