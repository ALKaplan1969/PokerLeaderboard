using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class Calculate
    {
        public static decimal GetMean(List<decimal> winnings)
        {
            return winnings.Average();
        }

        public static decimal GetMedian(List<decimal> winnings)
        {
            int count = winnings.Count;
            int halfIndex = winnings.Count / 2;
            var sortedWinnings = winnings.OrderBy(n => n).ToList();
            decimal median;
            if ((count % 2) == 0)
            {
                median = ((sortedWinnings.ElementAt(halfIndex) +
                    sortedWinnings.ElementAt((halfIndex - 1))) / 2);
            }
            else
            {
                median = sortedWinnings.ElementAt(halfIndex);
            }

            return median;
        }

        public static decimal GetMode(List<decimal> winnings)
        {
            return winnings.GroupBy(n => n)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key).FirstOrDefault();
        }

        public static decimal GetClosestValue(List<decimal> values, decimal targetNumber)
        {
            if (values != null)
                return values.OrderBy(x => Math.Abs((long)x - targetNumber)).First();
            else
                return 0;
        }
    }
}
