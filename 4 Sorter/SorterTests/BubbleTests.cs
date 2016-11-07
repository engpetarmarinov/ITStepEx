using Sorter;
using NUnit.Framework;

namespace SorterTests
{
    [TestFixture]
    public class BubbleTests
    {
        [Test]
        [TestCase(new [] { 1, 2, 3 }, new [] {1, 2, 3})]
        [TestCase(new[] { 7,2,3,6,1,2,3,7}, new[] { 1,2,2,3,3,6,7,7 })]
        [TestCase(new[] { 10, 50, 33, 2 }, new[] { 2, 10, 33, 50 })]
        [TestCase(new[] { 11,10,9 }, new[] { 9,10,11 })]
        public void OrderTest(int[] sort, int[] sorted)
        {
            var sorter = new Bubble();
            Assert.AreEqual(sorted, sorter.Order(sort));
        }
    }
}
