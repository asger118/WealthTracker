
using System.ComponentModel.DataAnnotations;

namespace BlazorStockApp.Shared.Models
{
    // "Index Fund", "Single Stock, "ETF",
    public class Sector
    {
        [Key]
        public int SectorId { get; set; }
        public string SectorName { get; set; }// Name of the sector (e.g., "Technology", "Healthcare", "Energy", "Oil & Gas", "Finance")
    }
}
