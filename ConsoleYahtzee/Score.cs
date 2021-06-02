using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleYahtzee
{
    public class Score
    {
        private static readonly IDictionary<string, int> singleScore = new Dictionary<string, int>
        {
            {"One", 1},
            {"Two", 2},
            {"Three", 3},
            {"Four", 4},
            {"Five", 5},
            {"Six", 6}
        };

        private readonly IDictionary<string, Func<int[], int>> scoring = new Dictionary<string, Func<int[], int>>
        {
            {"ThreeOfAKind", ScoreThreeOfAKind},
            {"FourOfAKind", ScoreFourOfAKind},
            {"FullHouse", ScoreFullHouse},
            {"SmallStraight", ScoreSmallStraight},
            {"LargeStraight", ScoreLargeStraight},
            {"Yahtzee", ScoreYahtzee},
            {"Chance", ScoreChance}
        };

        public int ScoreGame(int[] dice, string scoreCategory)
        {
            if (scoring.ContainsKey(scoreCategory))
            {
                return scoring[scoreCategory](dice);
            }

            return ScoreSingleNumber(dice, scoreCategory);
        }

        private static int ScoreSingleNumber(int[] dice, string scoringCategory)
        {
            var number = singleScore[scoringCategory];
            return dice.Where(x => x == number).Sum();
        }

        private static int ScoreChance(int[] dice)
        {
            return dice.Sum();
        }

        private static int ScoreThreeOfAKind(int[] dice)
        {
            return dice.GroupBy(x => x).Max(x => x.Count()) >= 3 ? dice.Sum() : 0;
        }

        private static int ScoreFourOfAKind(int[] dice)
        {
            return dice.GroupBy(x => x).Max(x => x.Count()) >= 4 ? dice.Sum() : 0;
        }

        private static int ScoreYahtzee(int[] dice)
        {
            return dice.All(x => x == dice[0]) ? 50 : 0;
        }

        private static int ScoreFullHouse(int[] dice)
        {
            return dice.GroupBy(x => x).Max(x => x.Count()) == 3 &&
                   dice.GroupBy(x => x).Min(x => x.Count()) == 2
                ? 25
                : 0;
        }

        private static int ScoreSmallStraight(int[] dice)
        {
            var sortedList = SortAndOrderList(dice);
            Remove5thDie(sortedList);
            
            var expectedStraight = Enumerable.Range(sortedList.First(), 4);
            return sortedList.SequenceEqual(expectedStraight) ? 30 : 0;
        }

        private static int ScoreLargeStraight(int[] dice)
        {
            var sortedList = SortAndOrderList(dice);
            var expectedStraight = Enumerable.Range(sortedList.First(), 5);
            return sortedList.SequenceEqual(expectedStraight) ? 40 : 0;
        }

        private static List<int> SortAndOrderList(int[] dice)
        {
            var sortedList = dice.OfType<int>().ToList();
            sortedList = sortedList.OrderBy(x => x).ToList();
            return sortedList;
        }
        
        private static void Remove5thDie(List<int> sortedList)
        {
            if (sortedList[0] + 1 == sortedList[1])
            {
                sortedList.Remove(sortedList.Last());
            }
            else
            {
                sortedList.Remove(sortedList.First());
            }
        }
    }
}