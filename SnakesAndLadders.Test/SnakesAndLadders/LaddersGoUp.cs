using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;


namespace SnakesAndLadders.Test.SnakesAndLadders
{
    public class LaddersGoUp
    {
        [Test]
        public void GivenThereIsALadderConnecting2And12_WhenTokenLandsOn2_TokenIsOn12()
        {
            //arrange
            Mock<IDice> dice = new Mock<IDice>();
            Game game = new Game(dice.Object, new List<Player> {
                new Player()
            });
            game.AddLadder(new Ladder() {
                fromSquare = 2,
                toSquare = 12
            });

            //act
            dice.SetupGet(m => m.Result).Returns(1);
            game.MoveToken(game.CurrentPlayer);

            //assert
            Assert.AreEqual(game.CurrentPlayer.TokenPosition, 12);
        }   

        [Test]
        public void GivenThereIsALadderConnecting2And12_WhenTokenLandsOn12_TokenIsOn12()
        {
            //arrange
            Mock<IDice> dice = new Mock<IDice>();
            Game game = new Game(dice.Object, new List<Player> {
                new Player()
            });
            game.AddLadder(new Ladder()
            {
                fromSquare = 2,
                toSquare = 12
            });

            //act
            dice.SetupGet(m => m.Result).Returns(11);
            game.MoveToken(game.CurrentPlayer);

            //assert
            Assert.AreEqual(game.CurrentPlayer.TokenPosition, 12);
        }
    }
}
