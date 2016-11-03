using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Academy
{
    public class Course
    {
        public string Name { get; set; }
        public int Duration { get; set; }
        public int MaxStudents { get; set; }

        public Course(string name, int duration, int numberStudents)
        {
            Name = name;
            Duration = duration;
            MaxStudents = numberStudents;
        }

        /// <summary>
        /// Course factory
        /// </summary>
        /// <param name="courseInfo"></param>
        /// <returns>An instance of Course</returns>
        public static Course CreateCourseFromString(string courseInfo)
        {
            var info = courseInfo.Split(new[] {"//"}, StringSplitOptions.None);
            var name = info[0];
            var max = int.Parse(info[1]);
            var duration = int.Parse(info[2]);
            return new Course(name, duration, max);
        }
    }
}
