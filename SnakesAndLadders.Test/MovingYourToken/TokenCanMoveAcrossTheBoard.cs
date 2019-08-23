using System;
using NUnit.Framework;
using static SnakesAndLadders.Game;

namespace SnakesAndLadders.Test.MovingYourToken
{
    public class TokenCanMoveAcrossTheBoard
    {

        [Test]
        public void GivenTheGameIsStarted_WhenTheTokenIsPlacedOnTheBoard_TokenIsOnSquare1()
        {
            Game game = new Game();
            Assert.AreEqual(game.GameState, GameStateEnum.isStarted);
            Assert.AreEqual(game.PlayerTokenPosition, 1);
        }

        [Test]
        public void GivenTheTokenIsOnSquare1_WhenTheTokenIsMoved3Spaces_TokenIsOnSqure4()
        {
            Game game = new Game();
            game.MoveToken(3);
            Assert.AreEqual(game.PlayerTokenPosition, 4);
        }

        [Test]
        public void GivenTheTokenIsOnSquare1_WhenTheTokenIsMoved3SpacesAndThen4Spaces_TokenIsOnSqure8()
        {
            Game game = new Game();
            game.MoveToken(3);
            game.MoveToken(4);
            Assert.AreEqual(game.PlayerTokenPosition, 8);
        }
    }
}
