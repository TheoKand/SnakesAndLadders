using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SnakesAndLadders.Test.MultiplePlayers
{
    public class DeterminingPlayOrder
    {
        [Test]
        public void GivenThereAreTwoPlayers_WhenTheGameIsStarted_PlayersMustRollDiceForPlayOrder()
        {
            //arrange
            List<Player> players = new List<Player>
                {
                    new Player()
                    {
                        PlayOrderDiceRoll=0
                    },
                    new Player()
                    {
                        PlayOrderDiceRoll=0
                    }
                };

            //act
            Game game = new Game(new Dice(), players);

            //assert
            players.ForEach(p => Assert.True(p.PlayOrderDiceRoll != 0));
        }

        [Test]
        public void GivenThePlayersAreRollingForPlayOrder_WhenPlayer1RollsHigher_Player1RollsFirst()
        {
            //arrange
            List<Player> players = new List<Player>
                {
                    new Player()
                    {
                        PlayOrderDiceRoll=6
                    },
                    new Player()
                    {
                        PlayOrderDiceRoll=1
                    }
                };

            //act
            Game game = new Game(new Dice(), players);

            //assert
            Assert.AreSame(game.CurrentPlayer, players[0]);
        }

        [Test]
        public void GivenThePlayersAreRollingForPlayOrder_WhenPlayer2RollsHigher_Player2RollsFirst()
        {
            //arrange
            List<Player> players = new List<Player>
                {
                    new Player()
                    {
                        PlayOrderDiceRoll=1
                    },
                    new Player()
                    {
                        PlayOrderDiceRoll=6
                    }
                };

            //act
            Game game = new Game(new Dice(), players);

            //assert
            Assert.AreSame(game.CurrentPlayer, players[1]);
        }

        [Test]
        public void GivenThePlayersAreRollingForPlayOrder_WhenPlayer1RollsSameAsPlayer2_PlayersRollAgain()
        {
            //arrange
            List<Player> players = new List<Player>
                {
                    new Player()
                    {
                        PlayOrderDiceRoll=6
                    },
                    new Player()
                    {
                        PlayOrderDiceRoll=6
                    }
                };

            //act
            Game game = new Game(new Dice(), players);

            //assert
            players.ForEach(p => Assert.True(p.DiceRolledForPlayOrder));
        }
    }
}
