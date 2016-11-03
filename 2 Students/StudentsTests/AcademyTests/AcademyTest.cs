using NUnit.Framework;
using Students;
using Students.Academy;
using Moq;

namespace StudentsTests.AcademyTests
{
    [TestFixture]
    public class AcademyTest
    {
        private Academy _academy;

        [SetUp]
        public void SetUp()
        {
            var myConsole = new Mock<IConsole>();
            _academy = new Academy(myConsole.Object);
        }

        [Test]
        public void AddCourseTest()
        {
            var course = new Course("C#", 2, 10);
            var course2 = new Course("F#", 4, 8);
            _academy.AddCourse(course);
            _academy.AddCourse(course2);
            Assert.AreEqual(2, _academy.Courses.Count);
            Assert.AreEqual(course, _academy.Courses[0]);
        }

        [Test]
        [TestCase("2", "C#//2//10", "F#//4//8")]
        public void EnterCoursesTest(params string[] input)
        {
            //mock IConsole and make sequence returns
            var myConsole = new Mock<IConsole>();
            var readlineSequence = myConsole.SetupSequence(c => c.ReadLine());
            foreach (var param in input)
            {
                readlineSequence.Returns(param);
            }
            var acc = new Academy(myConsole.Object);
            acc.EnterCourses();
            Assert.AreEqual(2, acc.Courses.Count);
        }

        [Test]
        public void AddStudentTest()
        {
            var student = new Student("Ivan Ivanov", 42);
            var myConsole = new Mock<IConsole>();
            var acc = new Academy(myConsole.Object);
            acc.AddStudent(student);
            acc.AddStudent(student);
            acc.AddStudent(student);
            Assert.AreEqual(3, acc.Students.Count);
        }
    }
}
