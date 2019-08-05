using System.Collections.Generic;
using System.Linq;
using TradingBot.Models;

namespace Model.CandelModels.Single
{
    public class Hammer
    {
        private IEnumerable<Candlestick> lstCandlestick { get; set; }
        public Hammer(IEnumerable<Candlestick> lstCandlestick)
        {
            this.lstCandlestick = lstCandlestick;
        }

        public Candlestick FindHammer()
        {
            List<Candlestick> hammers = FindHammers().ToList();
            List<Candlestick> lst = lstCandlestick.ToList();

            if (hammers.Count > 0)
            {
                int index = lst.ToList().FindIndex(ind => ind.NumberOfTrades == hammers.First().NumberOfTrades);
                if (lst[index + 2].Close <= lst[index + 1].Open && lst[index].Open <= lst[index + 1].Close)
                {
                    return lst[index - 1];
                }
                else if (lst[index + 2].Close >= lst[index + 1].Open && lst[index].Open >= lst[index + 1].Close)
                {
                    return lst[index - 1];
                }
            }
            return null;
        }

        public IEnumerable<Candlestick> FindHammers()
        {
            IEnumerable<Candlestick> withoutZeroDiff = lstCandlestick.Where(zero => (zero.Open - zero.Close) != 0);

            return (from value in withoutZeroDiff
                    where (value.Close - value.Low) / (value.Open - value.Close) >= 2
                    select value).ToList();
        }
    }
}
