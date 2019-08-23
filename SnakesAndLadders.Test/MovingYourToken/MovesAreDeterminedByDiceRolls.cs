using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;


namespace SnakesAndLadders.Test.MovingYourToken
{
    public class SnakesGoDown
    {

        [Test]
        public void GivenTheGameIsStarted_WhenThePlayerRollsADice_ResultIs1to6()
        {
            for(int i=0;i<1000;i++)
            {
                Game game = new Game();
                game.RollTheDice();
                Console.WriteLine($"Dice roll result={game.DiceRollResult}");
                Assert.GreaterOrEqual(game.DiceRollResult, 1);
                Assert.LessOrEqual(game.DiceRollResult, 6);
            }
        }

        [Test]
        public void GivenThePlayerRollsA4_WhenTheyMoveTheirToken_TokenMoves4Spaces()
        {
            Game game = new Game();
            int previousPlayerTokenPosition = game.Players[game.playerToPlayNext].TokenPosition;
            game.RollTheDice(4);
            Assert.AreEqual(game.DiceRollResult, 4);
            game.MoveToken(game.Players[game.playerToPlayNext]);
            Assert.AreEqual(game.Players[game.playerToPlayNext].TokenPosition, previousPlayerTokenPosition + 4);
        }
    }
}
