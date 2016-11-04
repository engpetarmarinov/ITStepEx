using NUnit.Framework;
using System;
using Students.University;

namespace StudentsTests.UniversityTests
{
    [TestFixture]
    public class CourseTest
    {
        [Test]
        [TestCase(1,"c#//22//2")]
        public void CreateCourseFromStringTest(int id, string info)
        {
            var course = Course.CreateCourseFromString(id, info);
            Assert.IsInstanceOf(typeof(Course), course);
            Assert.AreEqual(id, course.Id);
        }

        [Test]
        [TestCase(1, "c#//22")]
        [TestCase(2, "21321321")]
        [TestCase(3, "")]
        public void CreateCourseFromStringThrowsExceptionTest(int id, string info)
        {
            Assert.Throws<ArgumentException>(() => {
                var course = Course.CreateCourseFromString(id, info);
            });
        }

        [Test]
        [TestCase(3, 4, 5, 6)]
        [TestCase(3, 4, 5, 6, 7, 8, 9, 10)]
        public void AddStudentTest(params int[] ids)
        {
            var course = new Course(1, "test", 1, 100);
            foreach (var id in ids)
            {
                course.AddStudent(id);
            }
            Assert.AreEqual(ids.Length, course.Students.Count);

        }

        [Test]
        [TestCase(3, 4, 5, 6)]
        [TestCase(3, 4, 5, 6, 7, 8, 9, 10)]
        public void RemoveStudentTest(params int[] ids)
        {
            var course = new Course(1, "test", 1, 100);
            foreach (var id in ids)
            {
                course.AddStudent(id);
            }

            foreach (var id in ids)
            {
                course.RemoveStudent(id);
            }
            Assert.AreEqual(0, course.Students.Count);

        }


    }
}