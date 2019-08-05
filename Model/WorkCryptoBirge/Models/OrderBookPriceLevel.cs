using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class OrderBookPriceLevel
    {
        #region Public Properties

        /// <summary>
        /// Get the price.
        /// </summary>
        public decimal Price { get; }

        /// <summary>
        /// Get the aggregate quantity.
        /// </summary>
        public decimal Quantity { get; set; }

        #endregion Public Properties

        public OrderBookPriceLevel(decimal price, decimal quantity)
        {
            Price = price;
            Quantity = quantity;
        }
    }
}
