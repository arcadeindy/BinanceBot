using System.Collections.Generic;
using TradingBot.Models;

namespace Model.WorkCryptoBirge.Models
{
    public class OpenOrderList
    {
        public int OrderListId { get; set; }
        public ContingencyType ContingencyType { get; set; }     
        public ListStatusType ListStatusType { get; set; }
        public ListOrderStatus ListOrderStatus { get; set; }
        public string ListClientOrderId { get; set; }
        public long TransactionTime { get; set; }
        public string Symbol { get; set; }
        public List<Orders> Orders { get; set; }
    }

    public class Orders
    {
        public string Symbol { get; set; }
        public int OrderId { get; set; }
        public string ClientOrderId { get; set; }
    }
}
