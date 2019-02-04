using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public class LeaderBoard
    {
        public decimal Median { get; set; }
        public decimal Mean { get; set; }
        public List<Player> Players { get; set; }
    }

    public class Player
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public decimal Winnings { get; set; }
        public bool IsMedian { get; set; }
        public bool IsMean { get; set; }
    }
}
