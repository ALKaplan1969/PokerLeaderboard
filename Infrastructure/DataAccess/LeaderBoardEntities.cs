using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Specialized;
using System.Configuration;

namespace Infrastructure.DataAccess
{
    public class LeaderBoardEntities : ILeaderBoardEntities
    {
        NameValueCollection _appsettings = ConfigurationManager.AppSettings;

        public LeaderBoard AddPlayer(Player player, List<Player> playerList)
        {
            var leaderBoard = new LeaderBoard();
            leaderBoard.Players = playerList == null ? new List<Player>() : playerList;

            player.Id = (leaderBoard.Players.Count > 0) ? leaderBoard.Players.Select(x => x.Id).Max() + 1 : 1;
            leaderBoard.Players.Add(player);


            return leaderBoard;
        }

        public LeaderBoard UpdatePlayer(Player player, List<Player> playerList)
        {
            var leaderBoard = new LeaderBoard();
            leaderBoard.Players = playerList == null ? new List<Player>() : playerList;
            
            var updatedPlayer = leaderBoard.Players
                                .Where(p => p.Id == player.Id)
                                .Select(x => { x.Name = player.Name; x.Winnings = player.Winnings; return x; });


            return leaderBoard;
        }

        public LeaderBoard DeletePlayer(Player player, List<Player> playerList)
        {
            var leaderBoard = new LeaderBoard();
            leaderBoard.Players = playerList == null ? new List<Player>() : playerList;

            var deletePlayer = leaderBoard.Players.Remove(player);

            return leaderBoard;
        }

        public LeaderBoard RecalculateData(LeaderBoard leaderBoard)
        {

            var winnings = leaderBoard.Players.Select(x => x.Winnings).ToList();
            var mean = Calculate.GetMean(winnings);
            var median = Calculate.GetMedian(winnings);

            LeaderBoard lb = new LeaderBoard()
            {
                Median = median,
                Mean = mean,
                Players = leaderBoard.Players
            };

            //If player.count = 0 do not call
            //If player.count = 1, then set those values automatically
            if (lb.Players.Count != 0 && lb.Players.Count == 1)
            {
                lb.Players[0].IsMean = true;
                lb.Players[0].IsMedian = true;
            }
            else if (lb.Players.Count > 1)
            {
                var playersWinnings = lb.Players.Select(x => x.Winnings).ToList();
                var closestMean = Calculate.GetClosestValue(playersWinnings, mean);
                var closestMedian = Calculate.GetClosestValue(playersWinnings, median);
                var meanResults = lb.Players.Where(x => x.Winnings == closestMean).ToList();

                lb.Players.ForEach(y => y.IsMean = false);
                lb.Players.ForEach(y => y.IsMedian = false);

                lb.Players.Where(p => p.Winnings == closestMean).ToList().ForEach(y => y.IsMean = true);
                lb.Players.Where(p => p.Winnings == closestMedian).ToList().ForEach(y => y.IsMedian = true);
            }

            return lb;

        }

        public void SaveLeaderBoard(LeaderBoard leaderBoard)
        {
            var filePath = _appsettings["LocalPath"];

            //open file stream
            using (StreamWriter file = File.CreateText(filePath))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, leaderBoard);
            }
        }

        public LeaderBoard GetLeaderBoard()
        {
            try
            {
                var leaderBoard = new LeaderBoard();
                var filePath = _appsettings["LocalPath"];

                if (File.Exists(filePath))
                {
                    var json = File.ReadAllText(filePath);
                    leaderBoard = JsonConvert.DeserializeObject<LeaderBoard>(json);
                }

                return leaderBoard;

            }
            catch (FileNotFoundException notFountEx)
            {
                throw new FileNotFoundException("The File or the path was not found", notFountEx);
            }

        }
    }
}
