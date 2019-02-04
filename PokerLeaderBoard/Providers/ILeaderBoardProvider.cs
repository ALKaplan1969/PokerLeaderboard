using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Models;

namespace PokerLeaderBoard.Providers
{
    public interface ILeaderBoardProvider
    {
        LeaderBoard GetLeaderBoard();

        LeaderBoard AddPlayer(string playerName, decimal winnings, List<Player> playerList);

        LeaderBoard UpdatePlayer(Player player, List<Player> playerList);

        LeaderBoard DeletePlayer(Player player, List<Player> playerList);

        DataSet GetPlayers();

        void SaveLeaderBoard(LeaderBoard leaderBoard);
    }
}
