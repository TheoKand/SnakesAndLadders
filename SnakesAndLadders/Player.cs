using System;
using System.Collections.Generic;
using System.Text;

namespace SnakesAndLadders
{
    public class Player
    {
        public int TokenPosition;
        public bool IsComputerControlled;
        public int PlayOrderDiceRoll;

        public bool DiceRolledForPlayOrder { get; private set; }
        public bool IsWinner { get; private set; }

        public Player()
        {
            TokenPosition = 1;
            PlayOrderDiceRoll = 0;
            IsWinner = false;
        }

        public int RollDiceForPlayOrder(IDice dice)
        {
            dice.Roll();
            this.PlayOrderDiceRoll = dice.Result;
            this.DiceRolledForPlayOrder = true;
            return this.PlayOrderDiceRoll;
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
