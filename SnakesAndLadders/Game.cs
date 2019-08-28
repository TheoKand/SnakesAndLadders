using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakesAndLadders
{
    public class Game
    {

        private IDice dice;

        public int PlayerToPlayNext { get; private set; }
        public List<Snake> Snakes { get; private set; }
        public List<Ladder> Ladders { get; private set; }
        public List<Player> Players { get; private set; }

        public Game(IDice dice, List<Player> players)
        {
            this.dice = dice;
            this.Players = players;

            this.Snakes = new List<Snake>();
            this.Ladders = new List<Ladder>();

            this.DeterminePlayOrder();
            this.HandleComputerControlledCharacters();

        }

        private void HandleComputerControlledCharacters()
        {
            if (CurrentPlayer.IsComputerControlled)
            {
                this.RollTheDice();
                this.MoveToken(CurrentPlayer);
            }
        }

        private void DeterminePlayOrder()
        {
            while (OneOrMorePlayersHaveTheSamePlayOrderDiceRoll())
            {
                this.Players.ForEach(p =>
                {
                    p.RollDiceForPlayOrder(this.dice);
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
            if (player.TokenPosition + this.dice.Result > 100)
            {
                return;
            }

            player.TokenPosition += this.dice.Result;
            CheckForSnakesAndLadders();
            player.CheckIfPlayerHasWon();

            if (!player.IsWinner)
            {
                this.ModifyPlayOrder();
                this.HandleComputerControlledCharacters();
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

        public void CheckForSnakesAndLadders()
        {
            Snake snake = this.Snakes.FirstOrDefault(s => s.fromSquare == this.CurrentPlayer.TokenPosition);
            if (snake != null)
            {
                this.CurrentPlayer.TokenPosition = snake.toSquare;
            }

            Ladder ladder = this.Ladders.FirstOrDefault(s => s.fromSquare == this.CurrentPlayer.TokenPosition);
            if (ladder != null)
            {
                this.CurrentPlayer.TokenPosition = ladder.toSquare;
            }
        }

        public void RollTheDice()
        {
            this.dice.Roll();
        }

    }
}
