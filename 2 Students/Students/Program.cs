using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace Students
{
    internal class Program
    {
        
        private static void Main(string[] args)
        {
            //TODO: entering the number of courses

            //TODO: all the courses are entered, on a separate line, in this format courseName//duration//capacity

            //TODO: After that the program will read a number of students that will be created

            //TODO: After that, on each line the user will enter a new Student in this format name//age

            //TODO: Students will sign up to the courses, by using this syntax studentID courseID. If a student or course does not exist, throw an exception with the message “Student does not exist”, or “Course does not exist”, and handle it so that it prints “Error: ” + message, on the console. Also if the course`s capacity is already reached, you should have an exception printing “Course #nameOfCourse is already full!”.

            //TODO: After you enter `quit`, the program should print out all courses, sorted by name, and all the students assigned to the courses, sorted by age.

            //TODO: Try to use dependency injector
            // CREATE A WINDSOR CONTAINER OBJECT AND REGISTER THE INTERFACES, AND THEIR CONCRETE IMPLEMENTATIONS.
            var container = new WindsorContainer();
            container.Register(Component.For<People>());
            container.Register(Component.For<IConsole>().ImplementedBy<MyConsole>());

            // CREATE THE People OBJECT AND INVOKE ITS METHOD(S) AS DESIRED.
            var people = container.Resolve<People>();
            //var people = new People(new MyConsole());
            people.Read();
        }
    }
}
