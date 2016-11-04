using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.University
{
    public class Course
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public int MaxStudents { get; set; }

        private List<int> _students = new List<int>();
        public List<int> Students => _students;

        public Course(int id, string name, int duration, int numberStudents)
        {
            Id = id;
            Name = name;
            Duration = duration;
            MaxStudents = numberStudents;
        }
        
        /// <summary>
        /// Course factory
        /// </summary>
        /// <param name="id"></param>
        /// <param name="courseInfo">Format name//duration//max students</param>
        /// <returns>An instance of Course</returns>
        public static Course CreateCourseFromString(int id, string courseInfo)
        {
            
            var info = courseInfo.Split(new[] {"//"}, StringSplitOptions.None);
            var name = "";
            var max = 0;
            var duration = 0;
            try
            {
                name = info[0];
                max = int.Parse(info[1]);
                duration = int.Parse(info[2]);
            }
            catch 
            {
                throw new ArgumentException("Course info must be in format name//max students//hours");
            }
            return new Course(id, name, duration, max);
        }

        /// <summary>
        /// Adds a student id to the course
        /// </summary>
        /// <param name="studentId"></param>
        public void AddStudent(int studentId)
        {
            if (_students.Count >= MaxStudents)
            {
                throw new Exception($"The course {Name} is full! There are already {MaxStudents} attendies!");
            }
            if (_students.Find(s => s == studentId) == studentId)
            {
                throw new Exception($"This student is already in the course {Name}!");
            }
            _students.Add(studentId);
        }
    
        /// <summary>
        /// Removes a student from the course
        /// </summary>
        /// <param name="studentId"></param>
        public void RemoveStudent(int studentId)
        {
            _students.Remove(studentId);
        }

        public override string ToString()
        {
            return $"{Id} Course: {Name}//Duration: hours {Duration}//Max students: {MaxStudents}";
        }
    }
}
