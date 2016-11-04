using System;
using System.Collections.Generic;

namespace Students.University
{
    using Exceptions;

    public class Student : Person
    {
        public int Id { get; private set; }

        private List<int> _courses = new List<int>();
        public List<int> Courses => _courses;

        public Student(int id, string name, int age) : base(name, age)
        {
            Id = id;
        }

        /// <summary>
        /// Instanciate student by info
        /// </summary>
        /// <param name="id"></param>
        /// <param name="studentInfo"></param>
        /// <returns>A new student instance</returns>
        public static Student CreateStudentFromString(int id, string studentInfo)
        {
            var info = studentInfo.Split(new[] { "//" }, StringSplitOptions.None);
            var name = "";
            var age = 0;
            try
            {
                name = info[0];
                age = int.Parse(info[1]);
            }
            catch
            {
                throw new ArgumentException("Student info must be in format name//age");
            }
            var student = new Student(id, name, age);
            return student;
        }

        /// <summary>
        /// Checks if a student is siged up for any course
        /// </summary>
        /// <returns></returns>
        public bool IsSigned()
        {
            return _courses.Count > 0;
        }

        /// <summary>
        /// Checks if a student is signed up for the course ID
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        public bool IsSigned(int courseId)
        {
            var signed = _courses.Find(i => i == courseId);
            return signed == courseId;
        }

        /// <summary>
        /// Sign up for a course
        /// </summary>
        /// <param name="courseId"></param>
        public void SignupForCourse(int courseId)
        {
            if (IsSigned(courseId))
            {
                throw new StudentException("Student already signed");
            }
            _courses.Add(courseId);
        }

        public override string ToString()
        {
            return $"{Name}//{Age}";
        }
    }
}
