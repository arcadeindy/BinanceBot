using TradingBot.Models;

namespace TradingBot.Models
{
    public class Order
    {
        public string Symbol { get; set; }
        public long OrderId { get; set; }
        public string ClientOrderid { get; set; }
        public double Price { get; set; }
        public double OrigQty { get; set; }
        public string ExecutedQty { get; set; }
        public OrderStatuses Status { get; set; }
        public TimesInForce TimeInForce { get; set; }
        public OrderTypes Type { get; set; }
        public OrderSides Side { get; set; }
        public double StopPrice { get; set; }
        public double IcebergQty { get; set; }
        public long Time { get; set; }
    }
}
