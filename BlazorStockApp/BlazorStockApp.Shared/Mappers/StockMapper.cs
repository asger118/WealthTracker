
using BlazorStockApp.Shared.Models;
using BlazorStockApp.Shared.DTOs;

namespace BlazorStockApp.Shared.Mappers
{
    public class StockMapper : IStockMapper
    {
        public Stock Mapper(Rootobject dto)
        {
            var result = dto.chart.result[0];

            return new Stock
            {
                MetaData = new StockMeta
                {
                    Ticker = result.meta.symbol,
                    Name = result.meta.longName,
                    Currency = result.meta.currency,
                    ExchangeName = result.meta.exchangeName,
                    ValidHistoricalDataRange = result.meta.validRanges,
                    FirstTradeDate = result.meta.firstTradeDate,
                },
                realTimeData = new RealTimeData
                {
                    CurrentDataTime = result.meta.regularMarketTime,
                    CurrentPrice = result.meta.regularMarketPrice,
                    CurrentHigh = result.meta.regularMarketDayHigh,
                    CurrentLow = result.meta.regularMarketDayLow,
                    CurrentVolume = result.meta.regularMarketVolume,
                    PreviousClose = result.meta.previousClose,
                    TimezoneDifference = result.meta.gmtoffset,
                    RegularTradingPeriod = new RegularTradingPeriod
                    {
                        MarketOpenTime = result.meta.currentTradingPeriod.regular.start,
                        MarketCloseTime = result.meta.currentTradingPeriod.regular.end,
                        TimezoneDifference = result.meta.currentTradingPeriod.regular.gmtoffset,
                    },
                    YearlyHigh = result.meta.fiftyTwoWeekHigh,
                    YearlyLow = result.meta.fiftyTwoWeekLow,
                },
                hestoricalData = new HestoricalData
                {
                    HistoricalDataRange = result.meta.range,
                    TimeInterval = result.meta.dataGranularity,
                    Timestamps = result.timestamp.ToList(),
                    Volumes = result.indicators.quote[0].volume.ToList(),
                    HighPrices = result.indicators.quote[0].high.ToList(),
                    LowPrices = result.indicators.quote[0].low.ToList(),
                    OpenPrices = result.indicators.quote[0].open.ToList(),
                    ClosePrices = result.indicators.quote[0].close.ToList()
                }
            };
        }
    }
}
