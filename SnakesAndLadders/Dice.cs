using System;
using System.Collections.Generic;
using System.Text;

namespace SnakesAndLadders
{
    public interface IDice
    {
        int Result
        {
            get;
            set;
        }
        void Roll();
    }

    public class Dice : IDice
    {
        public int Result { get; set ; }

        void IDice.Roll()
        {
            int from = 1;
            int to = 6;
            Result = new Random(Guid.NewGuid().GetHashCode()).Next(from, to + 1);
        }
    }
}
