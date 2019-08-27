using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;


namespace SnakesAndLadders.Test.SnakesAndLadders
{
    public class SnakesGoDown
    {
        [Test]
        public void GivenThereIsASnakeConnecting2And12_WhenTokenLandsOn12_TokenIsOn2()
        {
            //arrange
            Mock<IDice> dice = new Mock<IDice>();
            Game game = new Game(dice.Object, new List<Player> {
                new Player()
                {
                    Name="Player1"
                }
            });
            game.AddSnake(new Snake() {
                fromSquare = 12,
                toSquare = 2
            });

            //act
            dice.SetupGet(m => m.Result).Returns(11);
            game.MoveToken(game.CurrentPlayer);

            //assert
            Assert.AreEqual(game.CurrentPlayer.TokenPosition, 2);
        }   

        [Test]
        public void GivenThereIsASnakeConnecting2And12_WhenTokenLandsOn2_TokenIsOn2()
        {
            //arrange
            Mock<IDice> dice = new Mock<IDice>();
            Game game = new Game(dice.Object, new List<Player> {
                new Player()
                {
                    Name="Player1"
                }
            });
            game.AddSnake(new Snake()
            {
                fromSquare = 12,
                toSquare = 2
            });

            //act
            dice.SetupGet(m => m.Result).Returns(1);
            game.MoveToken(game.CurrentPlayer);

            //assert
            Assert.AreEqual(game.CurrentPlayer.TokenPosition, 2);
        }
    }
}
