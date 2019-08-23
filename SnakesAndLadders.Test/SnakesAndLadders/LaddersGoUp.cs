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
            Game game = new Game();
            game.AddLadder(new Ladder() {
                fromSquare = 2,
                toSquare = 12
            });

            //act
            game.MoveToken(game.Players[game.playerToPlayNext],1);

            //assert
            Assert.AreEqual(game.Players[game.playerToPlayNext].TokenPosition, 12);
        }   

        [Test]
        public void GivenThereIsALadderConnecting2And12_WhenTokenLandsOn12_TokenIsOn12()
        {
            //arrange
            Game game = new Game();
            game.AddLadder(new Ladder()
            {
                fromSquare = 2,
                toSquare = 12
            });

            //act
            game.MoveToken(game.Players[game.playerToPlayNext], 11);

            //assert
            Assert.AreEqual(game.Players[game.playerToPlayNext].TokenPosition, 12);
        }
    }
}
