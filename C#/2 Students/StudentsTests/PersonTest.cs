using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using Students;

namespace StudentsTests
{    
    [TestFixture]
    public class PersonTest
    {
        [Test]
        [TestCase("Georgi", 20)]
        [TestCase("Gosho", 18)]
        [TestCase("Ivan", 43)]
        public void TestPersonWithNameAndAge(string name, int age)
        {
            var person = new Person(name, age);
            Assert.AreEqual(name, person.Name);
            Assert.AreEqual(age, person.Age);
        }

        [Test]
        [TestCase("Georgi")]
        [TestCase("Gosho")]
        [TestCase("Ivan")]
        public void TestPersonWithName(string name)
        {
            var person = new Person(name);
            Assert.AreEqual(name, person.Name);
            Assert.AreEqual(1, person.Age);
        }

        [Test]
        [TestCase(43)]
        [TestCase(20)]
        [TestCase(18)]
        [TestCase(0)]
        public void TestPersonWithName(int age)
        {
            var person = new Person(age);
            Assert.AreEqual("No Name", person.Name);
            Assert.AreEqual(age, person.Age);
        }

        [Test]
        [TestCase(-43)]
        public void TestPersonWithNegativeAgeException(int age)
        {
            Assert.Throws<ArgumentException>( () => {
                var person = new Person(age);
            });
        }
    }
}
