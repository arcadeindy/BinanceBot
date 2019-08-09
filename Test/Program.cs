using Model.API;
using Model.CandelModels;
using Model.Extension;
using Model.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

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

            var res = api.GetAccountInformationAsync();
            var res2 = api.GetCandleStickAsync("ETHBTC", "1h", TimeExtension.StartTime("6.07.2019 9:00"), TimeExtension.EndTime());
            var res3 = api.GetMyTradesAsync("ETHBTC");
            var res4 = api.GetOpenOrdersAsync("ETHBTC");
            var res6 = api.GetOrderBookAsync("ETHBTC", 500);

            Console.WriteLine("Завершился метод Main");

            Console.ReadKey();
        }

    }
}
