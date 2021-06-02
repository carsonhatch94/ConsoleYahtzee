using System.Collections.Generic;
using System.Linq;
using ConsoleYahtzee;
using NUnit.Framework;

namespace ConsoleYahtzeeTests
{
    public class RollTests
    {
        private Roll roll;
        [SetUp]
        public void SetUp()
        {
            roll = new Roll();
        }

        [Test]
        public void When_rolling_five_dice()
        {
            var result = roll.FirstRoll();
            Assert.That(result.Count, Is.EqualTo(5));
            foreach (var die in result)
            {
                Assert.That(Enumerable.Range(1,6).Contains(die));   
            }
        }
        
        [Test]
        public void When_rerolling_dice()
        {
            var diceToKeep = new List<int> {1, 2, 3};
            var result = roll.SubsequentRoll(diceToKeep);
            Assert.That(result.Count, Is.EqualTo(5));
            Assert.That(result.Contains(diceToKeep[0]));
            Assert.That(result.Contains(diceToKeep[1]));
            Assert.That(result.Contains(diceToKeep[2]));
        }
        
        [Test]
        public void When_rerolling_all_dice()
        {
            var diceToKeep = new List<int>();
            var result = roll.SubsequentRoll(diceToKeep);
            Assert.That(result.Count, Is.EqualTo(5));
        }
    }
}