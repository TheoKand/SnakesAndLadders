using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using static SnakesAndLadders.Game;

namespace SnakesAndLadders.Test.MovingYourToken
{
    public class PlayerCanWinTheGame
    {
        [Test]
        public void GivenTheTokenIsOnSquare97_WhenTheTokenIsMoved3Spaces_PlayerWinsGame()
        {
            //Arrange
            Game game = new Game();
            game.MoveToken(96);

            //Act
            game.MoveToken(3);

            //Assert
            Assert.AreEqual(game.PlayerTokenPosition, 100);
            Assert.AreEqual(game.GameState, GameStateEnum.playerHasWon);
        }

        [Test]
        public void GivenTheTokenIsOnSquare97_WhenTheTokenIsMoved4Spaces_PlayerDoestNotWinGame()
        {
            //Arrange
            Game game = new Game();
            game.MoveToken(96);

            //Act
            game.MoveToken(4);

            //Assert
            Assert.AreEqual(game.PlayerTokenPosition, 97);
            Assert.AreNotEqual(game.GameState, GameStateEnum.playerHasWon);
        }
    }
}
