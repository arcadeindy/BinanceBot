using Model.API;
using Model.Extension;
using System;
using System.Linq;
using System.Threading.Tasks;
using TradingBot.Models;

namespace Test
{
    class Program
    {
        static async Task Main(string[] args)
        {
            BinanceAPI api = new BinanceAPI(SettingsAPI.baseUrl);
            //var result = api.GetOrderBook("ETHBTC", 50);

            //WaveTheory wave = new WaveTheory();
            // var result = wave.Find(api.GetCandleStick("ETHBTC", "1h", TimeExtension.StartTime("6.07.2019 9:00"), TimeExtension.EndTime()));


            //var res = api.GetTickerPrice();

            // var symbols = (from x in res where x.PriceChangePercent >= 10 || x.PriceChangePercent <= -10 select x.Symbol).ToList();

            var result = api.OrderOCO("ETHBTC", OrderSides.BUY, 0.02m, 0.017m, 0.0172m);

  

            //var res = api.GetAccountInformation();
            //var res2 = api.GetCandleStickAsync("ETHBTC", "1h", TimeExtension.StartTime("6.07.2019 9:00"), TimeExtension.EndTime());
            //var res3 = api.GetMyTradesAsync("ETHBTC");
            //var res4 = api.GetOpenOrdersAsync("ETHBTC");
            //var res6 = api.GetOrderBookAsync("ETHBTC", 500);

            Console.WriteLine("Завершился метод Main");

            Console.ReadKey();
        }

    }
}
