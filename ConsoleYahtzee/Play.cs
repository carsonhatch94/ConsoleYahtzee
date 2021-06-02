using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ConsoleYahtzee
{
    class Play
    {
        static void Main(string[] args)
        {
            var firstRoll = new Roll().FirstRoll();
            Console.WriteLine("Let's play some Yahtzee!");
            foreach (var die in firstRoll)
            {
                Console.Write($"{die} ");
            }
            Console.WriteLine("\nSelect which dice to keep (2 rerolls remaining) or type SCORE to score current roll.");
            var input = Console.ReadLine();
            if (input == "SCORE")
            {
                Console.WriteLine("Insert Score stuph");
            }
            // var nextRoll = new Roll().SubsequentRoll()

        }

        private bool checkForValidInput(string input)
        {
            var result = Regex.Replace(input, "[^a-zA-Z0-9]", string.Empty);
            return false;
        } 
    }
}