namespace TradingBot.Models
{
    public class SymbolTicker
    {
        /// <summary>
        /// Currency
        /// </summary>
        public string Symbol { get; set; }
        /// <summary>
        /// Price on buy
        /// </summary>
        public double BidPrice { get; set; }
        /// <summary>
        /// Quantity on buy
        /// </summary>
        public double BidQty { get; set; }
        /// <summary>
        /// price on sell
        /// </summary>
        public double AskPrice { get; set; }
        /// <summary>
        /// Quantity on sell
        /// </summary>
        public double AskQty { get; set; }
    }
}
