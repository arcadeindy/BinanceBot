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
        static void Main(string[] args)
        {
            BinanceAPI api = new BinanceAPI(SettingsAPI.baseUrl);
            //var result = api.GetOrderBookAsync("ETHBTC", 50);

            WaveTheory wave = new WaveTheory();
            var result = wave.Find(api.GetCandleStick("ETHBTC", "1h", TimeExtension.StartTime("6.07.2019 9:00"), TimeExtension.EndTime()));

        }

    }
}
