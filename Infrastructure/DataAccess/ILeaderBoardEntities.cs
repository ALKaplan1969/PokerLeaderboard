using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataAccess
{
    public interface ILeaderBoardEntities
    {
        LeaderBoard AddPlayer(Player player, List<Player> playerList);

        LeaderBoard UpdatePlayer(Player player, List<Player> playerList);

        LeaderBoard DeletePlayer(Player player, List<Player> playerList);

        LeaderBoard RecalculateData(LeaderBoard leaderBoard);

        void SaveLeaderBoard(LeaderBoard leaderBoard);

        LeaderBoard GetLeaderBoard();

    }
}
