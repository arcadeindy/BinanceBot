using Model.Models;
using Model.Serilization.interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Model.Serilization
{
    public class OrderBookSerializer : ISerializer<OrderBook>
    {
        public OrderBookJsonConverter JsonConverter { get; }

        private readonly JsonSerializerSettings _settings;

        public OrderBookSerializer()
        {
            JsonConverter = new OrderBookJsonConverter();

            _settings = new JsonSerializerSettings();
            _settings.Converters.Add(JsonConverter);
        }

        public IEnumerable<OrderBook> DeserializeMany(string json)
        {
            throw new NotImplementedException();
        }

        public OrderBook Deserialize(string json)
        {
            return JsonConvert.DeserializeObject<OrderBook>(json, _settings);
        }

        public string Serialize(OrderBook type)
        {
            return JsonConvert.SerializeObject(type, _settings);
        }
    }
}
