using System;
using NUnit.Framework;
using List;
using System.Reflection;

namespace ListTests
{
    [TestFixture]
    public class ListGenericTests
    {

        [Test]
        public void ListGenericTest1()
        {

        }

        [Test]
        [TestCase(1,2,3,4,5,6,7,8,9,10)]
        [TestCase(6,6)]
        [TestCase()]
        public void GetTest(params int[] nums)
        {
            var list = new ListGeneric<int>();
            foreach (var i in nums)
            {
                list.Add(i);
            }
            Assert.AreEqual(nums.Length, list.Length);
        }

        [Test]
        public void AddTest()
        {

        }

        [Test]
        public void AddAtTest()
        {

        }

        [Test]
        public void RemoveAtTest()
        {

        }

        [Test]
        public void HasIndexTest()
        {

        }
    }
    
}