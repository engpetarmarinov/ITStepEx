using NUnit.Framework;
using System;
using Students.University;

namespace StudentsTests.UniversityTests
{
    [TestFixture]
    public class StudentTest
    {
        [Test]
        [TestCase(1, "name surname family//21")]
        public void CreateStudentFromStringTest(int id, string info)
        {
            var student = Student.CreateStudentFromString(id, info);
            Assert.IsInstanceOf(typeof(Student), student);
            Assert.AreEqual(id, student.Id);
        }

        [Test]
        [TestCase(1, "Petar Marinov")]
        [TestCase(2, "22")]
        [TestCase(3, "")]
        public void CreateStudentFromStringThrowsExceptionTest(int id, string info)
        {
            Assert.Throws<ArgumentException>(() => {
                var student = Student.CreateStudentFromString(id, info);
            });
        }

        [Test]
        public void IsSignedTest()
        {
            var student = new Student(1, "test", 22);
            Assert.AreEqual(false, student.IsSigned());
        }

        [Test]
        public void SignupForCourseTest()
        {
            var student = new Student(1, "test", 22);
            student.SignupForCourse(1);
            Assert.AreEqual(true, student.IsSigned(1));
        }
    }
}
