using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorStockApp.Shared.Models;

namespace BlazorStockApp.Data.Models
{
    public class Stock
    {
        // Meta Data
        [Key]
        public string Ticker { get; set; } = string.Empty; // Stock Ticker Symbol (e.g., AAPL)
        public string Name { get; set; } = string.Empty; // Full Name of the Stock (e.g., Apple Inc.)
        public string Currency { get; set; } = string.Empty; // Currency (e.g., USD)
        public string ExchangeName { get; set; } = string.Empty; // The exchange name (e.g., NASDAQ)
        public string[] ValidHistoricalDataRange { get; set; } = []; // valid ranges for graph
        public int FirstTradeDate { get; set; } // Can be used to calculate age of stock/company
        [ForeignKey("SectorId")]
        public int SectorId { get; set; }
        public string? IconType { get; set; }
        public byte[]? Icon { get; set; }
        public RegularTradingPeriod RegularTradingPeriod { get; set; } // Foreign Key

        // Current Price Data
        public int CurrentDataTime { get; set; } // The timestamp at wich the "Current*" data is from
        public float CurrentPrice { get; set; }
        public float CurrentHigh { get; set; }
        public float CurrentLow { get; set; }
        public int CurrentVolume { get; set; }
        public float PreviousClose { get; set; } // Used to calculate percent change for the day
        public int TimezoneDifference { get; set; } // The difference in seconds between local time and UTC
        public float YearlyHigh { get; set; }
        public float YearlyLow { get; set; }
    }
}
