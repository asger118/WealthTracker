
namespace BlazorStockApp.Shared.Models
{
    public class Stock
    {
        // Static meta data (non changing)
        public StockMeta MetaData { get; set; } 

        // Real-time data (dynamic and changing)
        public RealTimeData realTimeData;
        public HestoricalData hestoricalData;

        public Stock()
        {
            MetaData = new StockMeta();
            realTimeData = new RealTimeData();
            hestoricalData = new HestoricalData();
        }
    }
}
