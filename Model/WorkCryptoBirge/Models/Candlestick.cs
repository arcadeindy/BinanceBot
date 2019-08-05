using System;

namespace TradingBot.Models
{
    public class Candlestick
    {
        #region Public Properties

        /// <summary>
        /// Get the symbol.
        /// </summary>
        public string Symbol { get; }

        /// <summary>
        /// Get the interval.
        /// </summary>
        public string Interval { get; }

        /// <summary>
        /// Get the open time.
        /// </summary>
        public DateTime OpenTime { get; }

        /// <summary>
        /// Get the open price in quote asset units.
        /// </summary>
        public decimal Open { get; }

        /// <summary>
        /// Get the high price in quote asset units.
        /// </summary>
        public decimal High { get; }

        /// <summary>
        /// Get the low price in quote asset units.
        /// </summary>
        public decimal Low { get; }

        /// <summary>
        /// Get the close price in quote asset units.
        /// </summary>
        public decimal Close { get; }

        /// <summary>
        /// Get the volume in base asset units.
        /// </summary>
        public decimal Volume { get; }

        /// <summary>
        /// Get the close time.
        /// </summary>
        public DateTime CloseTime { get; }

        /// <summary>
        /// Get the volume in quote asset units.
        /// </summary>
        public decimal QuoteAssetVolume { get; }

        /// <summary>
        /// Get the number of trades.
        /// </summary>
        public long NumberOfTrades { get; }

        /// <summary>
        /// Get the taker buy base asset volume.
        /// </summary>
        public decimal TakerBuyBaseAssetVolume { get; }

        /// <summary>
        /// Get the taker buy quote asset volume.
        /// </summary>
        public decimal TakerBuyQuoteAssetVolume { get; }


        #endregion Public Properties

        #region Constructor
        public Candlestick(
            string symbol,
            string interval,
            DateTime openTime,
            decimal open,
            decimal high,
            decimal low,
            decimal close,
            decimal volume,
            DateTime closeTime,
            decimal quoteAssetVolume,
            long numberOfTrades,
            decimal takerBuyBaseAssetVolume,
            decimal takerBuyQuoteAssetVolume)
        {
            Symbol = symbol;
            Interval = interval;
            OpenTime = openTime;
            Open = open;
            High = high;
            Low = low;
            Close = close;
            Volume = volume;
            CloseTime = closeTime;
            QuoteAssetVolume = quoteAssetVolume;
            NumberOfTrades = numberOfTrades;
            TakerBuyBaseAssetVolume = takerBuyBaseAssetVolume;
            TakerBuyQuoteAssetVolume = takerBuyQuoteAssetVolume;
        }
        #endregion
    }
}
