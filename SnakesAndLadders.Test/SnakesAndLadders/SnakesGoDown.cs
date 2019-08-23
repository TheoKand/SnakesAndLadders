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
            Game game = new Game();
            game.AddSnake(new Snake() {
                fromSquare = 12,
                toSquare = 2
            });

            //act
            game.MoveToken(game.Players[game.playerToPlayNext], 11);

            //assert
            Assert.AreEqual(game.Players[game.playerToPlayNext].TokenPosition, 2);
        }   

        [Test]
        public void GivenThereIsASnakeConnecting2And12_WhenTokenLandsOn2_TokenIsOn2()
        {
            //arrange
            Game game = new Game();
            game.AddSnake(new Snake()
            {
                fromSquare = 12,
                toSquare = 2
            });

            //act
            game.MoveToken(game.Players[game.playerToPlayNext], 1);

            //assert
            Assert.AreEqual(game.Players[game.playerToPlayNext].TokenPosition, 2);
        }
    }
}
