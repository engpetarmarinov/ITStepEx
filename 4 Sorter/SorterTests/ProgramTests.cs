using NUnit.Framework;
using Moq;
using Sorter;
using System;
using System.Reflection;

namespace SorterTests
{
    [TestFixture]
    public class ProgramTests
    {
        [Test]
        [TestCase("5,6,3,2,1", new [] {5,6,3,2,1})]
        public void EnterArrayTest(string input, int[] output)
        {
            var myConsole = new Mock<ILogger>();
            var readlineSequence = myConsole.Setup(c => c.ReadLine()).Returns(input);
            
            var program = new Program(myConsole.Object);
            Assert.AreEqual(output, program.EnterArray() );
        }

        [Test]
        [TestCase("")]
        [TestCase("d")]
        [TestCase("1,")]
        [TestCase(",1")]
        [TestCase("1,d")]
        [TestCase("d,1")]
        public void EnterArrayExceptionTest(string input)
        {
            var myConsole = new Mock<ILogger>();
            myConsole.Setup(c => c.ReadLine()).Returns(input);
            var program = new Program(myConsole.Object);
            Assert.Throws<Exception>(() => {
                program.EnterArray();
            });
        }

        [Test]
        public void PrintArrayTest()
        {
            var myConsole = new Mock<ILogger>();
            var program = new Program(myConsole.Object);

            myConsole.Setup(c => c.WriteLine("1,2,3"));

            var privateMethod = program.GetType().GetMethod("PrintArray",
                BindingFlags.NonPublic | BindingFlags.Instance);

            privateMethod.Invoke(program, new object[] {new[] {1, 2, 3}});
            
        }
    }
}
