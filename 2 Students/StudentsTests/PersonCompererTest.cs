using NUnit.Framework;
using _2_Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Students.Tests
{
    [TestFixture]
    public class PersonCompererTest
    {
        [Test]
        public void CompareTest()
        {
            var comperer = new PersonComperer();

            var a = new Person("Ivan Marinov", 32);
            var b = new Person("Geogry Dsadsa", 22);
            Assert.AreEqual(-1, comperer.Compare(a, b));

            var c = new Person("Geogry Dimitrov", 32);
            var d = new Person("Ivan Marinov", 22);
            Assert.AreEqual(1, comperer.Compare(c, d));

            var e = new Person("Da Dsadsad", 32);
            var f = new Person("Da Wewqewqe", 22);
            Assert.AreEqual(0, comperer.Compare(e, f));
        }
    }
}