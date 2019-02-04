using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Infrastructure.Models;
using Infrastructure.DataAccess;
using System.Collections.Generic;
using System.Linq;

namespace PokerLeaderBoard.Test
{
    [TestClass]
    public class InfratructureTest
    {
        [TestMethod]
        public void TestAddPlayer()
        {
            LeaderBoard lb = new LeaderBoard();
            LeaderBoardEntities lbe = new LeaderBoardEntities();
            var playerList = new List<Player>();

            var player = new Player()
            {
                Name = "Test",
                Winnings = 100.23M
            };

            lb = lbe.AddPlayer(player, playerList);

            Assert.AreEqual(lb.Players.Count, 1);
            Assert.IsTrue(lb.Players.Contains(player));
        }

        [TestMethod]
        public void TestUpdatePlayer()
        {
            LeaderBoard lb = new LeaderBoard();
            LeaderBoardEntities lbe = new LeaderBoardEntities();
            var playerList = new List<Player>();
            var player = new Player()
            {
                Name = "Test",
                Winnings = 100.23M
            };
            playerList.Add(player);
            lb = lbe.AddPlayer(player, playerList);

            player.Winnings = 50.55M;

            lb = lbe.UpdatePlayer(player, playerList);

            Assert.AreEqual(lb.Players.Where(x => x.Name == "Test").FirstOrDefault().Winnings, 50.55M);
        }

        [TestMethod]
        public void TestDeletePlayer()
        {
            LeaderBoard lb = new LeaderBoard();
            LeaderBoardEntities lbe = new LeaderBoardEntities();
            var playerList = new List<Player>();
            var player = new Player()
            {
                Name = "Test",
                Winnings = 100.23M
            };
            lb = lbe.AddPlayer(player, playerList);

            Assert.AreEqual(lb.Players.Count, 1);

            lb = lbe.DeletePlayer(player, playerList);

            Assert.IsNull(lb.Players.Where(x => x.Name == "Test").FirstOrDefault());
        }

        [TestMethod]
        public void TestRecalculateMeanMedian()
        {
            LeaderBoard lb = new LeaderBoard();
            LeaderBoardEntities lbe = new LeaderBoardEntities();
            var playerList = new List<Player>();

            var player = new Player()
            {
                Name = "Test",
                Winnings = 25M
            };
            lb = lbe.AddPlayer(player, playerList);
            player = new Player()
            {
                Name = "Test",
                Winnings = 75M
            };
            lb = lbe.AddPlayer(player, playerList);
            lb.Mean = 0;
            lb.Median = 0;
            var updatedlb = lbe.RecalculateData(lb);

            Assert.AreEqual(updatedlb.Mean, 50M);
            Assert.IsTrue(updatedlb.Median != 0);
        }


    }
}
