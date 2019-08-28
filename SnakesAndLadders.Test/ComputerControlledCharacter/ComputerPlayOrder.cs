using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;

namespace SnakesAndLadders.Test.MovingYourToken
{
    public class ComputerPlayOrder
    {

        [Test]
        public void GivenComputerControllerCharacter_WhenGameIsStarted_ComputerShouldRollForItsTurnOrder()
        {
            //Arrange
            var computer = new Player()
            {
                Name = "Computer",
                IsComputerControlled = true
            };

            Game game = new Game(new Dice(), new List<Player> {
                computer,
                new Player()
                {
                    Name="Player"
                }
            });

            //Assert
            Assert.True(computer.DiceRolledForPlayOrder);
        }

        [Test]
        public void GivenComputerControllerCharacter_WhenItsThatCharactersTurn_TheyShouldRollAndMove()
        {
            //Arrange
            var computer = new Player()
            {
                Name = "Computer",
                IsComputerControlled = true,
                PlayOrderDiceRoll=6
            };

            Game game = new Game(new Dice(), new List<Player> {
                computer,
                new Player()
                {
                    Name="Player",
                    PlayOrderDiceRoll=1
                }
            });

            //Assert
            Assert.True(computer.TokenPosition!=1);
        }
    }
}