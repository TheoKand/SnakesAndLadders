using Moq;
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
            Mock<IDice> dice = new Mock<IDice>();
            Game game = new Game(dice.Object, new List<Player> {
                new Player()
            });
            dice.SetupGet(m => m.Result).Returns(96);
            game.MoveToken(game.CurrentPlayer);

            //Act
            dice.SetupGet(m => m.Result).Returns(3);
            game.MoveToken(game.CurrentPlayer);

            //Assert
            Assert.AreEqual(game.CurrentPlayer.TokenPosition, 100);
            Assert.True(game.CurrentPlayer.IsWinner);
        }

        [Test]
        public void GivenTheTokenIsOnSquare97_WhenTheTokenIsMoved4Spaces_PlayerDoesNotWinGame()
        {
            //Arrange
            Mock<IDice> dice = new Mock<IDice>();
            Game game = new Game(dice.Object, new List<Player> {
                new Player()
            });
            dice.SetupGet(m => m.Result).Returns(96);
            game.MoveToken(game.CurrentPlayer);

            //Act
            dice.SetupGet(m => m.Result).Returns(4);
            game.MoveToken(game.CurrentPlayer);

            //Assert
            Assert.AreEqual(game.CurrentPlayer.TokenPosition, 97);
            Assert.False(game.CurrentPlayer.IsWinner);
        }
    }
}
