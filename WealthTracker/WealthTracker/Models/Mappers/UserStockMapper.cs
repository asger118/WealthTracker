using WealthTracker.Models.DTOs;

namespace WealthTracker.Models.Mappers
{
    public class UserStockMapper
    {
        public Stock Map(Rootobject dto)
        {
            var result = dto.chart.result[0];

            return new Stock
            {
                // Meta Data
                Ticker = result.meta.symbol,
                Name = result.meta.longName,
                Currency = result.meta.currency,
                ExchangeName = result.meta.exchangeName,
                ValidHistoricalDataRange = result.meta.validRanges,
                FirstTradeDate = result.meta.firstTradeDate,
                RegularTradingPeriod = new RegularTradingPeriod
                {
                    MarketOpenTime = result.meta.currentTradingPeriod.regular.start,
                    MarketCloseTime = result.meta.currentTradingPeriod.regular.end,
                    TimezoneDifference = result.meta.currentTradingPeriod.regular.gmtoffset,
                },

                // Current Price Data
                CurrentDataTime = result.meta.regularMarketTime,
                CurrentPrice = result.meta.regularMarketPrice,
                CurrentHigh = result.meta.regularMarketDayHigh,
                CurrentLow = result.meta.regularMarketDayLow,
                CurrentVolume = result.meta.regularMarketVolume,
                PreviousClose = result.meta.previousClose,
                TimezoneDifference = result.meta.gmtoffset,
                YearlyHigh = result.meta.fiftyTwoWeekHigh,
                YearlyLow = result.meta.fiftyTwoWeekLow,
            };
        }
    }
}