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

        public int PlayerToPlayNext { get; private set; }
        public int DiceRollResult { get; private set; }
        public List<Snake> Snakes { get; private set; }
        public List<Ladder> Ladders { get; private set; }
        public List<Player> Players { get; private set; }

        public Game(List<Player> players)
        {
            this.Snakes = new List<Snake>();
            this.Ladders = new List<Ladder>();

            if (players == null)
            {
                this.Players = new List<Player>
                {
                    new Player()
                    {
                        Name="Player1"
                    },
                    new Player()
                    {
                        Name="Player2"
                    }
                };
            } else
            {
                this.Players = players;
            }

            this.DeterminePlayOrder();

        }

        private void DeterminePlayOrder()
        {
            while (OneOrMorePlayersHaveTheSamePlayOrderDiceRoll())
            {
                this.Players.ForEach(p =>
                {
                    p.RollDiceForPlayOrder();
                });
            }

            this.Players = this.Players.OrderByDescending(p => p.PlayOrderDiceRoll).ToList();

            this.PlayerToPlayNext = 0;
        }

        private bool OneOrMorePlayersHaveTheSamePlayOrderDiceRoll()
        {
            bool result = false;
            this.Players.ForEach(p =>
            {
                int thisPlayersDiceRoll = p.PlayOrderDiceRoll;
                Player otherPlayersWithSameDiceRoll = this.Players.FirstOrDefault(o => o != p && o.PlayOrderDiceRoll == thisPlayersDiceRoll);
                if (otherPlayersWithSameDiceRoll != null)
                {
                    result = true;
                }

            });
            return result;
        }

        public Player CurrentPlayer
        {
            get
            {
                return this.Players[this.PlayerToPlayNext];
            }
        }

        public void AddSnake(Snake snake)
        {
            this.Snakes.Add(snake);
        }

        public void AddLadder(Ladder ladder)
        {
            this.Ladders.Add(ladder);
        }

        public void MoveToken(Player player)
        {
            MoveToken(player, this.DiceRollResult);
        }

        public void MoveToken(Player player, int spaces)
        {
            if (player.TokenPosition + spaces > 100)
            {
                return;
            }

            player.TokenPosition += spaces;
            CheckForSnakesAndLadders(player);
            player.CheckIfPlayerHasWon();

            if (!player.IsWinner)
            {
                this.ModifyPlayOrder();
            }

        }

        private void ModifyPlayOrder()
        {
            this.PlayerToPlayNext++;
            if (this.PlayerToPlayNext>=this.Players.Count)
            {
                this.PlayerToPlayNext = 0;
            }
        }

        public void CheckForSnakesAndLadders(Player player)
        {
            Snake snake = this.Snakes.FirstOrDefault(s => s.fromSquare == player.TokenPosition);
            if (snake != null)
            {
                player.TokenPosition = snake.toSquare;
            }

            Ladder ladder = this.Ladders.FirstOrDefault(s => s.fromSquare == player.TokenPosition);
            if (ladder != null)
            {
                player.TokenPosition = ladder.toSquare;
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
