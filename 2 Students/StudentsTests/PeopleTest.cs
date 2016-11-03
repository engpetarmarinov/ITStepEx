using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using Students;
using Moq;

namespace StudentsTests
{
    [TestFixture]
    public class PeopleTest
    {
        [Test]
        [TestCase("Ivan Ivanov//43")]
        [TestCase("Banan Wilson//2")]
        public void TestAddPerson(string cmd)
        {
            var console = new Mock<IConsole>();
            var people = new People(console.Object);
            people.AddPerson(cmd);

            var data = cmd.Split(new[] {"//"}, StringSplitOptions.None);
            var name = data[0];
            var age = int.Parse(data[1]);

            var person = people.Collection[0];
            Assert.AreEqual(name, person.Name);
            Assert.AreEqual(age, person.Age);
        }
    }
}
