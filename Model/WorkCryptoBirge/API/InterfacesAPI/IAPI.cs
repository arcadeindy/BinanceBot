using Model.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using TradingBot.Models;

namespace Model.API
{
    public interface IAPI
    {
        OrderBook GetOrderBook(string symbol, int limit);
        Task<OrderBook> GetOrderBookAsync(string symbol, int limit);
        AccountInformation GetAccountInformation();
        Task<AccountInformation> GetAccountInformationAsync();
        Order[] GetOpenOrders(string symbol);
        Task<Order[]> GetOpenOrdersAsync(string symbol);
        Trades[] GetMyTrades(string symbol);
        Task<Trades[]> GetMyTradesAsync(string symbol);
        Trades GetLastTrade(string symbol);
        Task<Trades> GetLastTradeAsync(string symbol);
        IEnumerable<Candlestick> GetCandleStick(string symbol, string interval, int limit = 100);
        Task<IEnumerable<Candlestick>> GetCandleStickAsync(string symbol, string interval, int limit = 100);
        IEnumerable<Candlestick> GetCandleStick(string symbol, string interval, long startTime, long endTime);
        Task<IEnumerable<Candlestick>> GetCandleStickAsync(string symbol, string interval, long startTime, long endTime);
        Order PlaceOrder(string symbol, OrderSides side, OrderTypes type, TimesInForce timeInForce, double quantity, double price);
        Task<Order> PlaceOrderAsync(string symbol, OrderSides side, OrderTypes type, TimesInForce timeInForce, double quantity, double price);
        Order PlaceMarketOrder(string symbol, OrderSides side, double quantity);
        Task<Order> PlaceMarketOrderAsync(string symbol, OrderSides side, double quantity);
        void CancelOrder(string symbol, long orderId);
        Task CancelOrderAsync(string symbol, long orderId);
    }
}
