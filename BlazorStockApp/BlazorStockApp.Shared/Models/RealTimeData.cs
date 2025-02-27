using BlazorStockApp.Shared.DTOs;

namespace BlazorStockApp.Shared.Models
{
    public class RealTimeData
    {
        // Real-time data (dynamic and changing)
        public int CurrentDataTime { get; set; } // The timestamp at wich the "Current*" data is from
        public float CurrentPrice { get; set; }
        public float CurrentHigh { get; set; }
        public float CurrentLow { get; set; }
        public int CurrentVolume { get; set; }
        public float PreviousClose { get; set; } // Used to calculate percent change for the day
        public int TimezoneDifference { get; set; } // The difference in seconds between local time and UTC
        public RegularTradingPeriod RegularTradingPeriod { get; set; } // Class has info of when the market is open and closed
        public float YearlyHigh { get; set; }
        public float YearlyLow { get; set; }

        public RealTimeData() 
        {
            RegularTradingPeriod = new RegularTradingPeriod();
        }
    }
}