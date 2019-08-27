using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;

namespace SnakesAndLadders.Test.MovingYourToken
{
    public class SnakesGoDown
    {

        [Test]
        public void GivenTheGameIsStarted_WhenThePlayerRollsADice_ResultIs1to6()
        {
            for(int i=0;i<1000;i++)
            {
                //Arrange
                IDice dice = new Dice();
                Game game = new Game(dice, null);

                //Act
                game.RollTheDice();

                //Assert
                Assert.GreaterOrEqual(dice.Result, 1);
                Assert.LessOrEqual(dice.Result, 6);
            }
        }

        [Test]
        public void GivenThePlayerRollsA4_WhenTheyMoveTheirToken_TokenMoves4Spaces()
        {
            //Arrange
            Mock<IDice> dice = new Mock<IDice>();
            dice.SetupGet(m => m.Result).Returns(4);

            Game game = new Game(dice.Object, null);
            Player currentPlayer = game.CurrentPlayer;
            int previousPlayerTokenPosition = currentPlayer.TokenPosition;

            //Act
            game.RollTheDice();
            game.MoveToken(currentPlayer);

            //Assert
            Assert.AreEqual(currentPlayer.TokenPosition, previousPlayerTokenPosition + 4);
        }
    }
}
