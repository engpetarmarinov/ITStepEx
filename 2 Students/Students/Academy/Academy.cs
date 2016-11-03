using System.Collections.Generic;

namespace Students.Academy
{
    public class Academy
    {
        private readonly IConsole _console;
        public List<Course> Courses { get; set; } = new List<Course>();

        public Academy(IConsole console)
        {
            _console = console;
        }

        public void AddCourse(Course course)
        {
            Courses.Add(course);
        }

        public void EnterCourses()
        {
            _console.Write("Enter number of courses:");
            var numCoursesString = _console.ReadLine();
            var num = int.Parse(numCoursesString);

            for (var i = 0; i < num; i++)
            {
                _console.Write("Enter course in format name//max students//hours:");
                var courseInfo = _console.ReadLine();
                var course = Course.CreateCourseFromString(courseInfo);
                Courses.Add(course);
            }
        }
    }
}
