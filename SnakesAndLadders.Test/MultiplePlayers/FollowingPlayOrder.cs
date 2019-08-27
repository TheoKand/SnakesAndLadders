using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SnakesAndLadders.Test.MultiplePlayers
{
    public class FollowingPlayOrder
    {

        [Test]
        public void GivenItIsPlayer1Turn_WhenTheyHaveMoved_ItsPlayer2Turn()
        {
            //arrange

            List<Player> players = new List<Player>
                {
                    new Player()
                    {
                        Name="Player1",
                        PlayOrderDiceRoll=6
                    },
                    new Player()
                    {
                        Name="Player2",
                        PlayOrderDiceRoll=1
                    }
                };

            //act
            Game game = new Game(new Dice(), players);
            game.MoveToken(game.CurrentPlayer);

            //assert
            Assert.AreSame(game.CurrentPlayer, players[1]);
        }

        [Test]
        public void GivenItIsPlayer2Turn_WhenTheyHaveMoved_ItsPlayer1Turn()
        {
            //arrange
            List<Player> players = new List<Player>
                {
                    new Player()
                    {
                        Name="Player1",
                        PlayOrderDiceRoll=1
                    },
                    new Player()
                    {
                        Name="Player2",
                        PlayOrderDiceRoll=6
                    }
                };

            //act
            Game game = new Game(new Dice(), players);
            game.MoveToken(game.CurrentPlayer);

            //assert
            Assert.AreSame(game.CurrentPlayer, players[0]);
        }
    }
}
