using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingBot.Models;

namespace Model.CandelModels
{
    public class WaveTheory
    {
        public WaveTheory() { }

        public List<Candlestick> Find(IEnumerable<Candlestick> candelSticks)
        {
            var lst = candelSticks.ToList();
            var lstCandle = new List<Candlestick>();

            for (int i = 0; i < lst.Count() - 4; i++)
            {
                if( (lst[i+1].Close >= lst[i].Close && lst[i + 2].Close >= lst[i + 1].Close) 
                    && (lst[i+3].Close <= lst[i+2].Close && lst[i+4].Close <= lst[i + 3].Close))
                {
                    lstCandle.Add(lst[i + 2]);
                }
            }
            return lstCandle;
        }
    }
}
