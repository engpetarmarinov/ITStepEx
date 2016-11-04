using NUnit.Framework;
using Students;
using Students.University;
using Moq;

namespace StudentsTests.UniversityTests
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
            var course = new Course(_academy.GenerateCourseId(), "C#", 2, 10);
            var course2 = new Course(_academy.GenerateCourseId(), "F#", 4, 8);
            _academy.AddCourse(course);
            _academy.AddCourse(course2);
            Assert.AreEqual(2, _academy.Courses.Count);
            Assert.AreEqual(course, _academy.Courses[0]);
        }

        [Test]
        public void AddCourseAutoincrementTest()
        {
            var myConsole = new Mock<IConsole>();
            var acc = new Academy(myConsole.Object);
            var course = new Course(acc.GenerateCourseId(), "C#", 2, 10);
            var course2 = new Course(acc.GenerateCourseId(), "F#", 4, 8);
            acc.AddCourse(course);
            acc.AddCourse(course2);
            Assert.AreEqual(3, acc.GenerateCourseId());
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
            var myConsole = new Mock<IConsole>();
            var acc = new Academy(myConsole.Object);
            var student = new Student(acc.GenerateStudentId(), "Ivan Ivanov", 42);
            acc.AddStudent(student);
            acc.AddStudent(student);
            acc.AddStudent(student);
            Assert.AreEqual(3, acc.Students.Count);
        }

        [Test]
        [TestCase("4", "Petar Marinov//28", "Ivan Ivanov//27", "Dimitar Georgiev//31", "Maria Ivanova//23")]
        public void EnterStudentsTest(params string[] input)
        {
            //mock IConsole and make sequence returns
            var myConsole = new Mock<IConsole>();
            var readlineSequence = myConsole.SetupSequence(c => c.ReadLine());
            foreach (var param in input)
            {
                readlineSequence.Returns(param);
            }
            var acc = new Academy(myConsole.Object);
            acc.EnterStudents();
            Assert.AreEqual(4, acc.Students.Count);
        }

        [Test]
        [TestCase("1 1", "quit")]
        public void EnterSignupsTest(params string[] input)
        {
            //mock IConsole and make sequence returns
            var myConsole = new Mock<IConsole>();
            var readlineSequence = myConsole.SetupSequence(c => c.ReadLine());
            foreach (var param in input)
            {
                readlineSequence.Returns(param);
            }
            var acc = new Academy(myConsole.Object);
            var student = new Student(acc.GenerateStudentId(), "Ivan Ivanov", 42);
            acc.AddStudent(student);
            var course = new Course(_academy.GenerateCourseId(), "C#", 2, 10);
            acc.AddCourse(course);
            acc.EnterSignups();
            Assert.AreEqual(1, course.Students.Count);
            Assert.AreEqual(1, student.Courses.Count);
        }
    }
}
