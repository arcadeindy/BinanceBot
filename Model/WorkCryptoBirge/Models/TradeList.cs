namespace TradingBot.Models
{
    public class TradeList
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public decimal Qty { get; set; }
        public bool IsBuyerMaker { get; set; }
        public bool IsBestMatch { get; set; }
        public long Time { get; set; }
    }
}
