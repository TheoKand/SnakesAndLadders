using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using static SnakesAndLadders.Game;

namespace SnakesAndLadders.Test.MovingYourToken
{
    public class TokenCanMoveAcrossTheBoard
    {

        [Test]
        public void GivenTheGameIsStarted_WhenTheTokenIsPlacedOnTheBoard_TokenIsOnSquare1()
        {
            Game game = new Game(new Dice(), new List<Player> {
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

            Mock<IDice> dice = new Mock<IDice>();
            Game game = new Game(dice.Object, new List<Player> {
                new Player()
                {
                    Name="Player1"
                }
            });
            dice.SetupGet(m => m.Result).Returns(3);
            game.MoveToken(game.CurrentPlayer);
            Assert.AreEqual(game.CurrentPlayer.TokenPosition, 4);
        }

        [Test]
        public void GivenTheTokenIsOnSquare1_WhenTheTokenIsMoved3SpacesAndThen4Spaces_TokenIsOnSqure8()
        {
            //Arrange
            Mock<IDice> dice = new Mock<IDice>();
            Game game = new Game(dice.Object, new List<Player> {
                new Player()
                {
                    Name="Player1"
                }
            });
            dice.SetupGet(m => m.Result).Returns(3);

            //Act
            game.MoveToken(game.CurrentPlayer);
            dice.SetupGet(m => m.Result).Returns(4);
            game.MoveToken(game.CurrentPlayer);

            //Assert
            Assert.AreEqual(game.CurrentPlayer.TokenPosition, 8);
        }
    }
}
