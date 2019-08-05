using Model.Extension;
using Model.Serilization.interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TradingBot.Models;

namespace Model.Serilization
{
    public class CandlestickSerializer : ISerializer<Candlestick>
    {
        #region private const field  
        
        private const string KeySymbol = "symbol";
        private const string KeyInterval = "interval";
        private const string KeyOpenTime = "openTime";
        private const string KeyOpen = "open";
        private const string KeyHigh = "high";
        private const string KeyLow = "low";
        private const string KeyClose = "close";
        private const string KeyVolume = "volume";
        private const string KeyCloseTime = "closeTime";
        private const string KeyQuoteAssetVolume = "quoteAssetVolume";
        private const string KeyNumberOfTrades = "numberOfTrades";
        private const string KeyTakerBuyBaseAssetVolume = "takerBuyBaseAssetVolume";
        private const string KeyTakerBuyQuoteAssetVolume = "takerBuyQuoteAssetVolume";

        #endregion

        #region public fields

        public string symbol { get; set; }
        public string interval { get; set; }

        #endregion

        public CandlestickSerializer(string symbol, string interval)
        {
            this.symbol = symbol;
            this.interval = interval;
        }

        public IEnumerable<Candlestick> DeserializeMany(string json)
        {
            return JArray.Parse(json).Select(item => new Candlestick
            (
                symbol,
                interval,
                TimeExtension.ToDateTime(item[0].Value<long>()),    // open time
                item[1].Value<decimal>(), // open
                item[2].Value<decimal>(), // high
                item[3].Value<decimal>(), // low
                item[4].Value<decimal>(), // close
                item[5].Value<decimal>(), // volume
                TimeExtension.ToDateTime(item[6].Value<long>()),    // close time
                item[7].Value<decimal>(), // quote asset volume
                item[8].Value<long>(),    // number of trades
                item[9].Value<decimal>(), // taker buy base asset volume
                item[10].Value<decimal>() // taker buy quote asset volume
            )).ToArray();
        }
        public Candlestick Deserialize(string json)
        {
            var jToken = JToken.Parse(json);

            return new Candlestick(
                jToken[KeySymbol]?.Value<string>(),
                jToken[KeyInterval].Value<string>(),
                TimeExtension.ToDateTime(jToken[KeyOpenTime].Value<long>()),
                jToken[KeyOpen].Value<decimal>(),
                jToken[KeyHigh].Value<decimal>(),
                jToken[KeyLow].Value<decimal>(),
                jToken[KeyClose].Value<decimal>(),
                jToken[KeyVolume].Value<decimal>(),
                TimeExtension.ToDateTime(jToken[KeyCloseTime].Value<long>()),
                jToken[KeyQuoteAssetVolume].Value<decimal>(),
                jToken[KeyNumberOfTrades].Value<long>(),
                jToken[KeyTakerBuyBaseAssetVolume].Value<decimal>(),
                jToken[KeyTakerBuyQuoteAssetVolume].Value<decimal>());
        }
        public string Serialize(Candlestick type)
        {
            var jObject = new JObject
            {
                new JProperty(KeySymbol, type.Symbol),
                new JProperty(KeyInterval, type.Interval),
                new JProperty(KeyOpenTime, type.OpenTime),
                new JProperty(KeyOpen, type.Open.ToString(CultureInfo.InvariantCulture)),
                new JProperty(KeyHigh, type.High.ToString(CultureInfo.InvariantCulture)),
                new JProperty(KeyLow, type.Low.ToString(CultureInfo.InvariantCulture)),
                new JProperty(KeyClose, type.Close.ToString(CultureInfo.InvariantCulture)),
                new JProperty(KeyVolume, type.Volume.ToString(CultureInfo.InvariantCulture)),
                new JProperty(KeyCloseTime, type.CloseTime),
                new JProperty(KeyQuoteAssetVolume, type.QuoteAssetVolume.ToString(CultureInfo.InvariantCulture)),
                new JProperty(KeyNumberOfTrades, type.NumberOfTrades),
                new JProperty(KeyTakerBuyBaseAssetVolume, type.TakerBuyBaseAssetVolume.ToString(CultureInfo.InvariantCulture)),
                new JProperty(KeyTakerBuyQuoteAssetVolume, type.TakerBuyQuoteAssetVolume.ToString(CultureInfo.InvariantCulture))
            };

            return jObject.ToString(Formatting.None);
        }
    }
}
