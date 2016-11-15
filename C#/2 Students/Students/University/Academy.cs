using System.Collections.Generic;
using System;
using System.Text.RegularExpressions;

namespace Students.University
{
    using Exceptions;

    public class Academy
    {
        private readonly IConsole _console;

        /// <summary>
        /// List with all courses in the academy
        /// </summary>
        public List<Course> Courses { get; set; } = new List<Course>();

        /// <summary>
        /// List with all students
        /// </summary>
        public List<Student> Students { get; set; } = new List<Student>();

        public Academy(IConsole console)
        {
            _console = console;
        }

        /// <summary>
        /// Adds course to the academy
        /// </summary>
        /// <param name="course"></param>
        public void AddCourse(Course course)
        {
            Courses.Add(course);
        }

        /// <summary>
        /// Prompts for entering courses
        /// </summary>
        public void EnterCourses()
        {
            var num = 0;
            do
            {
                _console.Write("Enter number of courses:");
            } while (!int.TryParse(_console.ReadLine(), out num) || num < 0);

            for (var i = 0; i < num; i++)
            {
                _console.Write("Enter course in format name//max students//hours:");
                var courseInfo = _console.ReadLine();
                try
                {
                    var course = Course.CreateCourseFromString(GenerateCourseId(), courseInfo);
                    AddCourse(course);
                }
                catch (ArgumentException e)
                {
                    _console.WriteLine(e.Message);
                    i--;//a step back
                }
            }
        }

        /// <summary>
        /// Prompts for entering students
        /// </summary>
        public void EnterStudents()
        {
            var num = 0;
            do
            {
                _console.Write("Enter number of students:");
            } while (!int.TryParse(_console.ReadLine(), out num) || num < 0);

            for (var i = 0; i < num; i++)
            {
                _console.Write("Enter student in format name//age:");
                var studentInfo = _console.ReadLine();
                try
                {
                    var student = Student.CreateStudentFromString(GenerateStudentId(), studentInfo);
                    AddStudent(student);
                }
                catch (ArgumentException e)
                {
                    _console.WriteLine(e.Message);
                    i--;//a step back
                }

            }
        }

        /// <summary>
        /// Adds a new student to the academy
        /// </summary>
        /// <param name="student"></param>
        public void AddStudent(Student student)
        {
            Students.Add(student);
        }

        /// <summary>
        /// Generates a new ID for a student
        /// </summary>
        /// <returns></returns>
        public int GenerateStudentId()
        {
            return Students.Count + 1;
        }

        /// <summary>
        /// Generates a new course ID
        /// </summary>
        /// <returns></returns>
        public int GenerateCourseId()
        {
            return Courses.Count + 1;
        }
        
        /// <summary>
        /// Prompts for course signups
        /// </summary>
        public void EnterSignups()
        {
            while (true)
            {
                _console.Write("Enter \"studentID courseID\" in order to sign up a student for a course:");
                var cmd = _console.ReadLine();
                if (cmd == "quit")
                {
                    PrintCourses();
                    return;
                }
                try
                {
                    ParseCmd(cmd);
                }
                catch (Exception e)
                {
                    _console.WriteLine("Error: " + e.Message);
                }
            }

        }

        /// <summary>
        /// Parse a command and execute it
        /// </summary>
        /// <param name="cmd"></param>
        private void ParseCmd(string cmd)
        {
            var patternStudentSignUp = @"(\d+)\s(\d+)";
            var rgx = new Regex(patternStudentSignUp);
            var matches = rgx.Matches(cmd);
            
            if (matches.Count == 1 && matches[0].Groups.Count == 3)
            {
                var stId = int.Parse(matches[0].Groups[1].Value);
                var courId = int.Parse(matches[0].Groups[2].Value);
                Signup(stId, courId);
            }
            else
            {
                throw new Exception("Format \"studentID courseID\"!");
            }
        }

        private void PrintCourses()
        {
            foreach (var c in Courses)
            {
                _console.WriteLine($"{c}");
                var studentsIds = c.Students;
                foreach (var sId in studentsIds)
                {
                    var student = GetStudentById(sId);
                    _console.WriteLine($"{student}");
                }
            }
        }

        /// <summary>
        /// Sign a student to a course by IDs
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="courseId"></param>
        public void Signup(int studentId, int courseId)
        {
            var course = GetCourseById(courseId);
            var student = GetStudentById(studentId);
            if (student.IsSigned())
            {
                throw new Exception("Student is already signed!");
            }
            course.AddStudent(studentId);
            try
            {
                student.SignupForCourse(courseId);
            }
            catch (StudentException se)
            {
                //revert the adding of the student to the course
                course.RemoveStudent(studentId);
                throw new Exception(se.Message);
            }
        }

        /// <summary>
        /// Gets a student by ID
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        private Student GetStudentById(int studentId)
        {
            var student = Students.Find(s => s.Id == studentId);
            if (student == null)
            {
                throw new Exception("Student not found!");
            }
            return student;
        }

        /// <summary>
        /// Gets a course by ID
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        private Course GetCourseById(int courseId)
        {
            var course = Courses.Find(c => c.Id == courseId);
            if (course == null)
            {
                throw new Exception("Course not found!");
            }
            return course;
        }
    }
}
