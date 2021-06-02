using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleYahtzee
{
    public class Roll
    {
        public List<int> FirstRoll()
        {
            var result = new List<int>();
            for (int i = 0; i < 5; i++)
            {
                result.Add(DieRoll());
            }

            return result.OrderBy(x => x).ToList();
        }

        public List<int> SubsequentRoll(List<int> diceToKeep)
        {
            var result = new List<int>();
            foreach (var die in diceToKeep)
            {
                result.Add(die);
            }

            var rerolls = 5 - result.Count;
            for (int i = 0; i < rerolls; i++)
            {
                result.Add(DieRoll());
            }

            return result.OrderBy(x => x).ToList();

        }

        private int DieRoll()
        {
            var random = new Random();
            return random.Next(1, 7);
        }
    }
}