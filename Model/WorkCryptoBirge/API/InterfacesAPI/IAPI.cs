using Model.Models;
using Model.WorkCryptoBirge.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using TradingBot.Models;

namespace Model.API
{
    public interface IAPI
    {
        OpenOrderList[] GetOpenOrderList();
        Task<OpenOrderList[]> GetOpenOrderListAsync();
        TickerPrice[] GetTickerPrice();
        Task<TickerPrice[]> GetTickerPriceAsync();
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
        Order PlaceOrder(string symbol, OrderSides side, OrderTypes type, TimesInForce timeInForce, decimal quantity, decimal price);
        Task<Order> PlaceOrderAsync(string symbol, OrderSides side, OrderTypes type, TimesInForce timeInForce, decimal quantity, decimal price);
        Order PlaceMarketOrder(string symbol, OrderSides side, decimal quantity);
        Task<Order> PlaceMarketOrderAsync(string symbol, OrderSides side, decimal quantity);
        OrderOCO OrderOCO(string symbol, OrderSides side, decimal quantity, decimal price, decimal stopPrice);
        Task<OrderOCO> OrderOCOAsync(string symbol, OrderSides side, decimal quantity, decimal price, decimal stopPrice);
        void CancelOrder(string symbol, long orderId);
        Task CancelOrderAsync(string symbol, long orderId);
    }
}
