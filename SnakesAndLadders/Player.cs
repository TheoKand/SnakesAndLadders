using System;
using System.Collections.Generic;
using System.Text;

namespace SnakesAndLadders
{
    public class Player
    {
        public string Name;
        public int TokenPosition;
        public bool IsWinner;
        public int PlayOrderDiceRoll;
        public bool DiceRolledForPlayOrder { get; private set; }

        public Player()
        {
            TokenPosition = 1;
            PlayOrderDiceRoll = 0;
            IsWinner = false;
        }

        public int RollDiceForPlayOrder()
        {
            int from = 1;
            int to = 6;
            int diceRollResult = new Random(Guid.NewGuid().GetHashCode()).Next(from, to + 1);
            this.PlayOrderDiceRoll = diceRollResult;
            this.DiceRolledForPlayOrder = true;
            return diceRollResult;
        }

        public void CheckIfPlayerHasWon()
        {
            if (this.TokenPosition == 100)
            {
                IsWinner = true;
            }
        }
    }
}
