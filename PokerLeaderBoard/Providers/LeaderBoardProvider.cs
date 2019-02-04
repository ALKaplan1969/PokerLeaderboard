using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Models;
using Infrastructure.DataAccess;
using PokerLeaderBoard.Providers;
using System.Data;

namespace PokerLeaderBoard
{
    public class LeaderBoardProvider : ILeaderBoardProvider
    {
        private readonly ILeaderBoardEntities _leaderBoard;

        public LeaderBoardProvider ()
        {
            _leaderBoard = new LeaderBoardEntities();
        }
        public LeaderBoard GetLeaderBoard()
        {
            return _leaderBoard.GetLeaderBoard();
        }

        public LeaderBoard AddPlayer(string playerName, decimal winnings, List<Player> playerList)
        {
            try
            {
                Player player = new Player()
                {
                    Name = playerName,
                    Winnings = winnings
                };

                LeaderBoard lb = _leaderBoard.AddPlayer(player, playerList);
                return _leaderBoard.RecalculateData(lb); 
            }
            catch (Exception ex)
            {
                throw new Exception("There was a problem saving the player information", ex);
            }

        }

        public LeaderBoard UpdatePlayer(Player player, List<Player> playerList)
        {
            try
            {
                LeaderBoard lb = _leaderBoard.UpdatePlayer(player, playerList);
                return _leaderBoard.RecalculateData(lb);
            }
            catch (Exception ex)
            {
                throw new Exception("There was a problem updating the player information", ex);
            }
        }

        public LeaderBoard DeletePlayer(Player player, List<Player> playerList)
        {
            try
            {
                LeaderBoard lb = _leaderBoard.DeletePlayer(player, playerList);
                if (lb.Players.Count > 0)
                    return _leaderBoard.RecalculateData(lb);
                else
                    return new LeaderBoard();
            }
            catch (Exception ex)
            {
                throw new Exception("There was a problem deleteing the player information", ex);
            }
        }

        public void SaveLeaderBoard(LeaderBoard leaderBoard)
        {
            try
            {
                _leaderBoard.SaveLeaderBoard(leaderBoard);
            }
            catch (Exception ex)
            {
                throw new Exception("There was a problem saving the leader board information", ex);
            }
            
        }
    }
}
