using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;

namespace Model.Models
{
    public class OrderBookJsonConverter : JsonConverter
    {
        /// <summary>
        /// Get or set flag to include OrderBook.Symbol in JSON.
        /// </summary>
        public bool SerializeSymbol { get; set; } = true;

        private const string KeyLastUpdateId = "lastUpdateId";
        private const string KeyBids = "bids";
        private const string KeyAsks = "asks";

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(OrderBook);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);

            long lastUpdateId = jObject[KeyLastUpdateId].Value<long>();

            var bids = jObject[KeyBids]
                .Select(_ => (_[0].Value<decimal>(), _[1].Value<decimal>()))
                .ToArray();

            var asks = jObject[KeyAsks]
                .Select(_ => (_[0].Value<decimal>(), _[1].Value<decimal>()))
                .ToArray();

            return new OrderBook(lastUpdateId, bids, asks);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (!(value is OrderBook orderBook))
                return;

            var jObject = new JObject();

            jObject.Add(new JProperty(KeyLastUpdateId, orderBook.LastUpdateId));
            jObject.Add(new JProperty(KeyBids, orderBook.Bids.Select(_ => new JArray { _.Price, _.Quantity })));
            jObject.Add(new JProperty(KeyAsks, orderBook.Asks.Select(_ => new JArray { _.Price, _.Quantity })));

            jObject.WriteTo(writer);
        }
    }
}
