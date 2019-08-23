using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakesAndLadders
{
    public class Game
    {

        public enum GameStateEnum
        {
            isStarted,
            playerHasWon
        }

        public GameStateEnum GameState { get; private set; }
        public int PlayerTokenPosition { get; private set; }
        public int DiceRollResult { get; private set; }
        public List<Snake> Snakes { get; private set; }
        public List<Ladder> Ladders { get; private set; }

        public Game()
        {
            this.GameState = GameStateEnum.isStarted;
            this.PlayerTokenPosition = 1;
            this.Snakes = new List<Snake>();
            this.Ladders = new List<Ladder>();
        }

        public void AddSnake(Snake snake)
        {
            this.Snakes.Add(snake);
        }

        public void AddLadder(Ladder ladder)
        {
            this.Ladders.Add(ladder);
        }

        public void MoveToken()
        {
            MoveToken(this.DiceRollResult);
        }

        public void MoveToken(int spaces)
        {
            if (this.PlayerTokenPosition+spaces > 100) return;

            this.PlayerTokenPosition += spaces;
            CheckForSnakesAndLadders();
            CheckIfPlayerHasWon();
            
        }

        public void CheckForSnakesAndLadders()
        {
            Snake snake = this.Snakes.FirstOrDefault(s => s.fromSquare == this.PlayerTokenPosition);
            if (snake!=null)
            {
                this.PlayerTokenPosition = snake.toSquare;
            }

            Ladder ladder = this.Ladders.FirstOrDefault(s => s.fromSquare == this.PlayerTokenPosition);
            if (ladder != null)
            {
                this.PlayerTokenPosition = ladder.toSquare;
            }
        }

        public void CheckIfPlayerHasWon()
        {
            if (this.PlayerTokenPosition==100)
            {
                this.GameState = GameStateEnum.playerHasWon;
            }
        }

        public void RollTheDice()
        {
            int from = 1;
            int to = 6;
            int diceRollResult = new Random(Guid.NewGuid().GetHashCode()).Next(from, to + 1);
            RollTheDice(diceRollResult);
        }

        public void RollTheDice(int diceRollResult)
        {
            this.DiceRollResult = diceRollResult;
        }
    }
}
