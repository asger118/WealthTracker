
using System.ComponentModel.DataAnnotations;

namespace WealthTracker.Models
{
    // "Index Fund", "Single Stock, "ETF",
    public class Sector
    {
        [Key]
        public int SectorId { get; set; }
        public required string SectorName { get; set; } // Name of the sector (e.g., "Technology", "Healthcare", "Energy", "Oil & Gas", "Finance")
        public required string SectorDescription { get; set; }// Description of the sector
    }
}
