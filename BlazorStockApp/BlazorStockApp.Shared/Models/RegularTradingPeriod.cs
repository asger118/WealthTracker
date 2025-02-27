
namespace BlazorStockApp.Shared.Models
{
    public class RegularTradingPeriod
    {
        public int MarketOpenTime { get; set; } // Time for when market opens
        public int MarketCloseTime { get; set; } // Time for when market closes
        public int TimezoneDifference { get; set; } // The difference in seconds between local time and UTC
    }
}
