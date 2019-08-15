using Model.Extension;
using Model.Models;
using Model.Requests;
using Model.Serilization;
using Model.WorkCryptoBirge.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using TradingBot.Models;

namespace Model.API
{
    public class BinanceAPI : IAPI
    {
        public string baseUrl { get; set; }
        public Request request { get; set; }
        public BinanceAPI(string baseUrl)
        {
            this.baseUrl = baseUrl;
            request = new Request();
        }

        #region synchronous methods

        /// <summary>
        /// Cancel order
        /// </summary>
        /// <param name="symbol">currency</param>
        /// <param name="orderId">id of irder</param>
        public void CancelOrder(string symbol, long orderId)
        {
            string apiRequestUrl = $"{baseUrl}v3/order";

            string query = $"symbol={symbol}&orderId={orderId}";

            query = $"{query}&timestamp={TimeExtension.getTimeStamp()}";

            var signature = request.getSignature(SettingsAPI.SecretKey, query);
            query += "&signature=" + signature;

            apiRequestUrl += "?" + query;
            var response = request.webRequest(apiRequestUrl, "DELETE", SettingsAPI.ApiKey);
        }

        /// <summary>
        /// Get AccountInformation including all Asset Balances
        /// </summary>
        /// <returns></returns>
        /// 
        public AccountInformation GetAccountInformation()
        {
            string apiRequestUrl = $"{baseUrl}v3/account";

            string query = $"";
            query = $"{query}&timestamp={TimeExtension.getTimeStamp()}";

            var signature = request.getSignature(SettingsAPI.SecretKey, query);
            query += "&signature=" + signature;

            apiRequestUrl += "?" + query;

            var response = request.webRequest(apiRequestUrl, "GET", SettingsAPI.ApiKey);

            System.Console.WriteLine("GetAccountInformation");

            var parsedResponse = JsonConvert.DeserializeObject<AccountInformation>(response);
            return parsedResponse;
        }

        /// <summary>
        /// Get a candle
        /// </summary>
        /// <param name="symbol">currency</param>
        /// <param name="interval">period</param>
        /// <param name="limit">quantity. default 100</param>
        /// <returns></returns>
        public IEnumerable<Candlestick> GetCandleStick(string symbol, string interval, int limit = 100)
        {
            string apiRequestUrl = $"{baseUrl}v1/klines";

            string query = $"symbol={symbol}&interval={interval}&limit={limit}";

            apiRequestUrl += "?" + query;

            string response = request.webRequest(apiRequestUrl, "GET", SettingsAPI.ApiKey);
            System.Console.WriteLine("GetCandleStick");
            CandlestickSerializer candlestick = new CandlestickSerializer(symbol, interval);
            return candlestick.DeserializeMany(response);
        }

        /// <summary>
        /// get a candle
        /// </summary>
        /// <param name="symbol">currency</param>
        /// <param name="interval">period</param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public IEnumerable<Candlestick> GetCandleStick(string symbol, string interval, long startTime, long endTime)
        {
            string apiRequestUrl = $"{baseUrl}v1/klines";

            string query = $"symbol={symbol}&interval={interval}&startTime={startTime}&endTime={endTime}";

            apiRequestUrl += "?" + query;

            string response = request.webRequest(apiRequestUrl, "GET", SettingsAPI.ApiKey);
            System.Console.WriteLine("GetCandleStick");
            return new CandlestickSerializer(symbol, interval).DeserializeMany(response);
        }

        /// <summary>
        /// Gets the last trade
        /// </summary>
        /// <param name="symbol">currency</param>
        /// <returns>Trade object</returns>
        public Trades GetLastTrade(string symbol)
        {
            var parsedResponse = GetMyTrades(symbol);

            if (parsedResponse.Length != 0)
                return parsedResponse[parsedResponse.Length - 1];
            else
                return null;
        }

        /// <summary>
        /// get the prices
        /// </summary>
        /// <param name="symbol">currency</param>
        /// <param name="limit">quantity prices</param>
        /// <returns></returns>
        public OrderBook GetOrderBook(string symbol, int limit)
        {
            string apiRequestUrl = $"{baseUrl}v1/depth?symbol={symbol}&limit={limit}";
            string response = request.webRequest(apiRequestUrl, "GET", SettingsAPI.ApiKey);

            OrderBookSerializer orderSerializer = new OrderBookSerializer();
            System.Console.WriteLine("GetOrderBook");
            return orderSerializer.Deserialize(response);
        }

        /// <summary>
        /// get all trades of current currency
        /// </summary>
        /// <param name="symbol">currency</param>
        /// <returns>all trades</returns>
        public Trades[] GetMyTrades(string symbol)
        {
            string apiRequestUrl = $"{baseUrl}v3/myTrades";

            string query = $"symbol={symbol}";

            query = $"{query}&timestamp={TimeExtension.getTimeStamp()}";

            var signature = request.getSignature(SettingsAPI.SecretKey, query);
            query += "&signature=" + signature;

            apiRequestUrl += "?" + query;

            var response = request.webRequest(apiRequestUrl, "GET", SettingsAPI.ApiKey);
            System.Console.WriteLine("GetMyTrades");
            var parsedResponse = JsonConvert.DeserializeObject<Trades[]>(response);
            return parsedResponse;
        }

        /// <summary>
        /// get a open orders of currency in current time
        /// </summary>
        /// <param name="symbol">currency</param>
        /// <returns>A list of Trades</returns>
        public Order[] GetOpenOrders(string symbol)
        {
            string apiRequestUrl = $"{baseUrl}v3/openOrders";

            string query = $"symbol={symbol}";

            query = $"{query}&timestamp={TimeExtension.getTimeStamp()}";

            var signature = request.getSignature(SettingsAPI.SecretKey, query);

            query += "&signature=" + signature;

            apiRequestUrl += "?" + query;

            var response = request.webRequest(apiRequestUrl, "GET", SettingsAPI.ApiKey);
            System.Console.WriteLine("GetOpenOrders");
            var parsedResponse = JsonConvert.DeserializeObject<Order[]>(response);
            return parsedResponse;
        }

        /// <summary>
        /// Places a market order
        /// </summary>
        /// <param name="symbol">currency</param>
        /// <param name="side">Order side, Buy or Sell</param>
        /// <param name="quantity">Amount to be traded</param>
        /// <returns></returns>
        public Order PlaceMarketOrder(string symbol, OrderSides side, double quantity)
        {
            string newQuantity = quantity.ToString();
            newQuantity = newQuantity.Replace(',', '.');

            string apiRequestUrl = $"{baseUrl}v3/order";

            string query = $"symbol={symbol}&side={side}&type={OrderTypes.MARKET}&quantity={newQuantity}";

            query = $"{query}&timestamp={TimeExtension.getTimeStamp()}";

            var signature = request.getSignature(SettingsAPI.SecretKey, query);
            query += "&signature=" + signature;

            apiRequestUrl += "?" + query;
            var response = request.webRequest(apiRequestUrl, "POST", SettingsAPI.ApiKey);

            var parsedResponse = JsonConvert.DeserializeObject<Order>(response);
            return parsedResponse;
        }

        /// <summary>
        /// Places an order
        /// </summary>
        /// <param name="symbol">currency</param>
        /// <param name="side">>Order Side, BUY or SELL</param>
        /// <param name="type">Order Type, see Enum.OrderTypes</param>
        /// <param name="timeInForce">Time order will be active for</param>
        /// <param name="quantity">Amount to be traded</param>
        /// <param name="price">Price to be bought/sold at</param>
        /// <returns>The order object</returns>
        public Order PlaceOrder(string symbol, OrderSides side, OrderTypes type, TimesInForce timeInForce, double quantity, double price)
        {
            string newPrice = price.ToString();
            newPrice = newPrice.Replace(',', '.');

            string newQuantity = quantity.ToString();
            newQuantity = newQuantity.Replace(',', '.');

            string apiRequestUrl = $"{baseUrl}v3/order";

            string query = $"symbol={symbol}&side={side}&type={type}&timeInForce={timeInForce}&quantity={newQuantity}&price={newPrice}";

            query = $"{query}&timestamp={TimeExtension.getTimeStamp()}";

            var signature = request.getSignature(SettingsAPI.SecretKey, query);
            query += "&signature=" + signature;

            apiRequestUrl += "?" + query;
            var response = request.webRequest(apiRequestUrl, "POST", SettingsAPI.ApiKey);

            var parsedResponse = JsonConvert.DeserializeObject<Order>(response);
            return parsedResponse;
        }

        public TickerPrice[] GetTickerPrice()
        {
            string apiRequestUrl = $"{baseUrl}v1/ticker/24hr";
            string response = request.webRequest(apiRequestUrl, "GET", SettingsAPI.ApiKey);

            return JsonConvert.DeserializeObject<TickerPrice[]>(response);
        }

        #endregion

        #region asynchronous methods
        public async Task<Order[]> GetOpenOrdersAsync(string symbol)
        {
            return await Task.Run(() => GetOpenOrders(symbol));
        }

        public async Task<Trades[]> GetMyTradesAsync(string symbol)
        {
            return await Task.Run(() => GetMyTrades(symbol));
        }

        public async Task<Trades> GetLastTradeAsync(string symbol)
        {
            return await Task.Run(() => GetLastTrade(symbol));
        }

        public async Task<AccountInformation> GetAccountInformationAsync()
        {
            return await Task.Run(() => GetAccountInformation());
        }

        public async Task<IEnumerable<Candlestick>> GetCandleStickAsync(string symbol, string interval, int limit = 100)
        {
            return await Task.Run(() => GetCandleStick(symbol, interval));
        }

        public async Task<IEnumerable<Candlestick>> GetCandleStickAsync(string symbol, string interval, long startTime, long endTime)
        {
            return await Task.Run(() => GetCandleStick(symbol, interval, startTime, endTime));
        }

        public async Task<Order> PlaceOrderAsync(string symbol, OrderSides side, OrderTypes type, TimesInForce timeInForce, double quantity, double price)
        {
            return await Task.Run(() => PlaceOrder(symbol, side, type, timeInForce, quantity, price));
        }

        public async Task<Order> PlaceMarketOrderAsync(string symbol, OrderSides side, double quantity)
        {
            return await Task.Run(() => PlaceMarketOrder(symbol, side, quantity));
        }

        public async Task CancelOrderAsync(string symbol, long orderId)
        {
            await Task.Run(() => CancelOrder(symbol, orderId));
        }

        public async Task<OrderBook> GetOrderBookAsync(string symbol, int limit)
        {
            return await Task.Run(() => GetOrderBook(symbol, limit));
        }

        public async Task<TickerPrice[]> GetTickerPriceAsync()
        {
            return await Task.Run(() => GetTickerPrice());
        }

        #endregion
    }
}
