using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;

namespace SnakesAndLadders.Test.MovingYourToken
{
    public class ComputerPlaying
    {
        [Test]
        public void GiveGameIsStarted_WhenItsComputersTurn_ComputerShouldRollAndMove()
        {
            //Arrange
            var computer = new Player()
            {
                IsComputerControlled = true,
                PlayOrderDiceRoll=1,
            };
            var human = new Player()
            {
                PlayOrderDiceRoll = 6
            };

            Game game = new Game(new Dice(), new List<Player> { computer, human });

            //Assert
            game.RollTheDice();
            game.MoveToken(human);

            //make sure computer has moved
            Assert.AreNotEqual(computer.TokenPosition, 1);
            Assert.AreSame(game.CurrentPlayer, human);
        }

    }
}