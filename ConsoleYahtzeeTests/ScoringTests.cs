using ConsoleYahtzee;
using NUnit.Framework;

namespace ConsoleYahtzeeTests
{
    public class ScoringTests
    {
        private Score score;

        [SetUp]
        public void Setup()
        {
            score = new Score();
        }

        [TestCase(new[]{1,2,3,4,5}, "One", 1)]
        [TestCase(new[]{1,1,3,4,5}, "One", 2)]
        [TestCase(new[]{2,2,3,4,5}, "Two", 4)]
        [TestCase(new[]{2,2,3,4,5}, "One", 0)]
        [TestCase(new[]{1,3,3,4,5}, "Three", 6)]
        [TestCase(new[]{1,3,3,4,5}, "Four", 4)]
        [TestCase(new[]{1,5,5,5,5}, "Five", 20)]
        [TestCase(new[]{1,3,3,6,6}, "Six", 12)]
        [TestCase(new[]{1,1,1,4,5}, "ThreeOfAKind", 12)]
        [TestCase(new[]{1,2,2,4,5}, "ThreeOfAKind", 0)]
        [TestCase(new[]{5,5,5,5,6}, "FourOfAKind", 26)]
        [TestCase(new[]{5,5,5,6,6}, "FourOfAKind", 0)]
        [TestCase(new[]{5,5,5,6,6}, "FullHouse", 25)]
        [TestCase(new[]{3,3,3,1,1}, "FullHouse", 25)]
        [TestCase(new[]{1,2,3,4,6}, "SmallStraight", 30)]
        [TestCase(new[]{6,5,3,4,1}, "SmallStraight", 30)]
        [TestCase(new[]{6,5,2,4,1}, "SmallStraight", 0)]
        [TestCase(new[]{1,2,4,4,4}, "SmallStraight", 0)]
        [TestCase(new[]{1,1,3,4,5}, "SmallStraight", 0)]
        [TestCase(new[]{6,5,2,4,3}, "LargeStraight", 40)]
        [TestCase(new[]{4,5,2,3,1}, "LargeStraight", 40)]
        [TestCase(new[]{4,6,2,3,1}, "LargeStraight", 0)]
        [TestCase(new[]{1,1,1,1,1}, "Yahtzee", 50)]
        [TestCase(new[]{1,1,1,1,2}, "Yahtzee", 0)]
        [TestCase(new[]{1,2,3,4,5}, "Chance", 15)]
        public void When_scoring(int[] dice, string category, int expectedScore)
        {
            Assert.That(score.ScoreGame(dice, category), Is.EqualTo(expectedScore));
        }
    }
}