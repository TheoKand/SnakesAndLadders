using System;
using System.Collections.Generic;
using NUnit.Framework;
using static SnakesAndLadders.Game;

namespace SnakesAndLadders.Test.MovingYourToken
{
    public class TokenCanMoveAcrossTheBoard
    {

        [Test]
        public void GivenTheGameIsStarted_WhenTheTokenIsPlacedOnTheBoard_TokenIsOnSquare1()
        {
            Game game = new Game(new List<Player> {
                new Player()
                {
                    Name="Player1"
                }
            });
            Assert.AreEqual(game.CurrentPlayer.TokenPosition, 1);
        }

        [Test]
        public void GivenTheTokenIsOnSquare1_WhenTheTokenIsMoved3Spaces_TokenIsOnSqure4()
        {
            Game game = new Game(new List<Player> {
                new Player()
                {
                    Name="Player1"
                }
            });
            game.MoveToken(game.CurrentPlayer,3);
            Assert.AreEqual(game.CurrentPlayer.TokenPosition, 4);
        }

        [Test]
        public void GivenTheTokenIsOnSquare1_WhenTheTokenIsMoved3SpacesAndThen4Spaces_TokenIsOnSqure8()
        {
            Game game = new Game(new List<Player> {
                new Player()
                {
                    Name="Player1"
                }
            });
            game.MoveToken(game.CurrentPlayer,3);
            game.MoveToken(game.CurrentPlayer,4);
            Assert.AreEqual(game.CurrentPlayer.TokenPosition, 8);
        }
    }
}
