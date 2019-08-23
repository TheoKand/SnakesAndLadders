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
            Assert.AreEqual(game.Players[game.playerToPlayNext].TokenPosition, 1);
        }

        [Test]
        public void GivenTheTokenIsOnSquare1_WhenTheTokenIsMoved3Spaces_TokenIsOnSqure4()
        {
            Game game = new Game();
            game.MoveToken(game.Players[game.playerToPlayNext],3);
            Assert.AreEqual(game.Players[game.playerToPlayNext].TokenPosition, 4);
        }

        [Test]
        public void GivenTheTokenIsOnSquare1_WhenTheTokenIsMoved3SpacesAndThen4Spaces_TokenIsOnSqure8()
        {
            Game game = new Game();
            game.MoveToken(game.Players[game.playerToPlayNext],3);
            game.MoveToken(game.Players[game.playerToPlayNext],4);
            Assert.AreEqual(game.Players[game.playerToPlayNext].TokenPosition, 8);
        }
    }
}
