namespace WealthTracker.Models.DTOs
{
    public class HestoricalData
    {
        // Historical data for charts (Timestamps and Indicators)
        public string HistoricalDataRange { get; set; } = string.Empty; // Total time period covered (e. g. 1d, 5d, 1mo, 3mo, 6mo, 1y, 2y, 5y, 10y, ytd, max)
        public string TimeInterval { get; set; } = string.Empty; // Interval between data points (e. g. 1m, 5m, 1d)
        public List<int> Timestamps { get; set; } = new List<int>(); // Timestamps for historical data (e.g., UNIX timestamp)
        public List<int>? Volumes { get; set; } // Volume of trades for each time interval
        public List<float>? HighPrices { get; set; } // High prices for each time interval
        public List<float>? LowPrices { get; set; } // Low prices for each time interval
        public List<float>? OpenPrices { get; set; } // Opening prices for each time interval
        public List<float>? ClosePrices { get; set; } // Closing prices for each time interval
    }
}