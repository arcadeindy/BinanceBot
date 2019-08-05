namespace TradingBot.Models
{
    public class Trades
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public double Price { get; set; }
        public double Qty { get; set; }
        public string Commission { get; set; }
        public string commissionAsset { get; set; }
        public long Time { get; set; }
        public bool isBuyer { get; set; }
        public bool isMaker { get; set; }
        public bool isBestMatch { get; set; }
    }
}
