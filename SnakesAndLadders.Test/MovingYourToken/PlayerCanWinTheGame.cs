using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using static SnakesAndLadders.Game;

namespace SnakesAndLadders.Test.MovingYourToken
{
    public class PlayerCanWinTheGame
    {
        [Test]
        public void GivenTheTokenIsOnSquare97_WhenTheTokenIsMoved3Spaces_PlayerWinsGame()
        {
            //Arrange
            Game game = new Game(new Dice(), new List<Player> {
                new Player()
                {
                    Name="Player1"
                }
            });
            game.MoveToken(game.CurrentPlayer, 96);

            //Act
            game.MoveToken(game.CurrentPlayer, 3);

            //Assert
            Assert.AreEqual(game.CurrentPlayer.TokenPosition, 100);
            Assert.True(game.CurrentPlayer.IsWinner);
        }

        [Test]
        public void GivenTheTokenIsOnSquare97_WhenTheTokenIsMoved4Spaces_PlayerDoesNotWinGame()
        {
            //Arrange
            Game game = new Game(new Dice(), new List<Player> {
                new Player()
                {
                    Name="Player1"
                }
            });
            game.MoveToken(game.CurrentPlayer, 96);

            //Act
            game.MoveToken(game.CurrentPlayer, 4);

            //Assert
            Assert.AreEqual(game.CurrentPlayer.TokenPosition, 97);
            Assert.False(game.CurrentPlayer.IsWinner);
        }
    }
}
