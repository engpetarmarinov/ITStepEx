using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Students.University;

namespace Students
{
    internal class Program
    {
        
        private static void Main(string[] args)
        {
            
            //TODO: Try to use dependency injector
            // CREATE A WINDSOR CONTAINER OBJECT AND REGISTER THE INTERFACES, AND THEIR CONCRETE IMPLEMENTATIONS.
            var container = new WindsorContainer();
            container.Register(Component.For<People>());
            container.Register(Component.For<Academy>());//reg Academy
            container.Register(Component.For<IConsole>().ImplementedBy<MyConsole>());

            // CREATE THE People OBJECT AND INVOKE ITS METHOD(S) AS DESIRED.
            //var people = container.Resolve<People>();
            //var people = new People(new MyConsole());
            //people.Read();

            //init the academy
            var academy = container.Resolve<Academy>();

            // entering the number of courses
            // all the courses are entered, on a separate line, in this format courseName//duration//capacity
            academy.EnterCourses();

            // the program will read a number of students that will be created
            // on each line the user will enter a new Student in this format name//age
            academy.EnterStudents();

            // Students will sign up to the courses, by using this syntax studentID courseID. 
            // If a student or course does not exist, throw an exception with the message “Student does not exist”, 
            // or “Course does not exist”, and handle it so that it prints “Error: ” + message, on the console. 
            // Also if the course`s capacity is already reached, you should have an exception printing “Course #nameOfCourse is already full!”.
            // After you enter `quit`, the program should print out all courses, sorted by name, and all the students assigned to the courses, sorted by age.
            academy.EnterSignups();
        }
    }
}
