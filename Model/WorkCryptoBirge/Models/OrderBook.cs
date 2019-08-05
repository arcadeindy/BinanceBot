using System.Collections.Generic;
using System.Linq;

namespace Model.Models
{
    public class OrderBook
    {
        #region Public Properties

        /// <summary>
        /// Get the last update ID.
        /// </summary>
        public long LastUpdateId { get; private set; }

        /// <summary>
        /// Get the buyer bids in order of decreasing price.
        /// </summary>
        public IEnumerable<OrderBookPriceLevel> Bids { get; private set; }

        /// <summary>
        /// Get the seller asks in order of increasing price.
        /// </summary>
        public IEnumerable<OrderBookPriceLevel> Asks { get; private set; }

        #endregion Public Properties

        #region Private Fields

        private readonly SortedDictionary<decimal, OrderBookPriceLevel> _bids;
        private readonly SortedDictionary<decimal, OrderBookPriceLevel> _asks;

        #endregion Private Fields

        public OrderBook(long lastUpdateId, IEnumerable<(decimal, decimal)> bids, IEnumerable<(decimal, decimal)> asks)
        {
            LastUpdateId = lastUpdateId;

            _bids = new SortedDictionary<decimal, OrderBookPriceLevel>();
            _asks = new SortedDictionary<decimal, OrderBookPriceLevel>();

            foreach (var bid in bids)
            {
                _bids.Add(bid.Item1, new OrderBookPriceLevel(bid.Item1, bid.Item2));
            }

            foreach (var ask in asks)
            {
                _asks.Add(ask.Item1, new OrderBookPriceLevel(ask.Item1, ask.Item2));
            }

            Bids = _bids.Values.ToArray();
            Asks = _asks.Values.ToArray();
        }
    }
}
