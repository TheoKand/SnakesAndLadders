﻿using System;
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
        public int playerToPlayNext { get; private set; }
        public int DiceRollResult { get; private set; }
        public List<Snake> Snakes { get; private set; }
        public List<Ladder> Ladders { get; private set; }
        public List<Player> Players { get; private set; }

        public Game()
        {
            this.GameState = GameStateEnum.isStarted;
            this.Snakes = new List<Snake>();
            this.Ladders = new List<Ladder>();
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
            if (player.TokenPosition+spaces > 100) return;

            player.TokenPosition += spaces;
            CheckForSnakesAndLadders(player);
            CheckIfPlayerHasWon(player);
            
        }

        public void CheckForSnakesAndLadders(Player player)
        {
            Snake snake = this.Snakes.FirstOrDefault(s => s.fromSquare == player.TokenPosition);
            if (snake!=null)
            {
                player.TokenPosition = snake.toSquare;
            }

            Ladder ladder = this.Ladders.FirstOrDefault(s => s.fromSquare == player.TokenPosition);
            if (ladder != null)
            {
                player.TokenPosition = ladder.toSquare;
            }
        }

        public void CheckIfPlayerHasWon(Player player)
        {
            if (player.TokenPosition == 100)
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
