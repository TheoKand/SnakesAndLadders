using System;

namespace SnakesAndLadders
{
    public class Game
    {
        public bool IsStarted { get; private set; }
        public int PlayerTokenPosition { get; private set; }
        public int DiceRollResult { get; private set; }

        public Game()
        {
            this.IsStarted = false;
            this.PlayerTokenPosition = 1;
        }

        public void MoveToken()
        {
            MoveToken(this.DiceRollResult);
        }

        public void MoveToken(int spaces)
        {
            this.PlayerTokenPosition += spaces;
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
