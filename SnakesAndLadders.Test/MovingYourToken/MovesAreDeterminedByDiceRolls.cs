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
                Game game = new Game(null);
                game.RollTheDice();
                Console.WriteLine($"Dice roll result={game.DiceRollResult}");
                Assert.GreaterOrEqual(game.DiceRollResult, 1);
                Assert.LessOrEqual(game.DiceRollResult, 6);
            }
        }

        [Test]
        public void GivenThePlayerRollsA4_WhenTheyMoveTheirToken_TokenMoves4Spaces()
        {
            Game game = new Game(null);
            int previousPlayerTokenPosition = game.CurrentPlayer.TokenPosition;
            game.RollTheDice(4);
            Assert.AreEqual(game.DiceRollResult, 4);
            game.MoveToken(game.CurrentPlayer);
            Assert.AreEqual(game.CurrentPlayer.TokenPosition, previousPlayerTokenPosition + 4);
        }
    }
}
