﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;


namespace SnakesAndLadders.Test.MovingYourToken
{
    public class MovesAreDeterminedByDiceRolls
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
            int previousPlayerTokenPosition = game.PlayerTokenPosition;
            game.RollTheDice(4);
            Assert.AreEqual(game.DiceRollResult, 4);
            game.MoveToken();
            Assert.AreEqual(game.PlayerTokenPosition, previousPlayerTokenPosition + 4);
        }
    }
}