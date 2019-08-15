using System.Collections.Generic;
using TradingBot.Models;

namespace Model.WorkCryptoBirge.Models
{
    public class OrderOCO
    {
        public List<OpenOrderList> OpenOrderLists { get; set; }
        public List<OrderReports> OrderReports { get; set; }
    }

    public class OrderReports
    {
        public string Symbol { get; set; }
        public int OrderId { get; set; }
        public int OrderListId { get; set; }
        public string ClientOrderId { get; set; }
        public long TransactTime { get; set; }
        public decimal Price { get; set; }
        public decimal OrigQty { get; set; }
        public decimal ExecutedQty { get; set; }
        public decimal CummulativeQuoteQty { get; set; }
        public OrderStatuses Status { get; set; }
        public TimesInForce TimeInForce { get; set; }
        public OrderTypes Type { get; set; }
        public OrderSides Side { get; set; }
        public decimal StopPrice { get; set; }
    }
}
