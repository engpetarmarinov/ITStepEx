using System;
using System.Collections.Generic;

namespace Students
{
    public class People
    {
        private readonly IConsole _console;
        /// <summary>
        /// People under this age will be filtered
        /// </summary>
        private const int AgeLimit = 18;

        public List<Person> Collection { get; private set; } = new List<Person>();

        public People(IConsole console)
        {
            _console = console;
        }

        /// <summary>
        /// Reads user input and parses the command
        /// </summary>
        public void Read()
        {
            while (true)
            {
                _console.Write("Enter person name//age or 'quit':");
                var command = _console.ReadLine()?.Trim();
                ParseCommand(command);
            }
        }

        /// <summary>
        /// Parse the command
        /// </summary>
        /// <param name="cmd"></param>
        public void ParseCommand(string cmd)
        {
            switch (cmd)
            {
                case "quit":
                    PrintAll();
                    Quit();
                    break;
                default:
                    AddPerson(cmd);
                    break;
            }
        }

        /// <summary>
        /// Prints all people, filtered and sorted
        /// </summary>
        private void PrintAll()
        {
            Collection.Sort(new PersonComperer());

            foreach (var person in Collection)
            {
                if (person.Age >= AgeLimit)
                {
                    _console.WriteLine($"{person.Name} is {person.Age} years old.");
                }
            }
        }

        /// <summary>
        /// Adds a person to the group
        /// </summary>
        /// <param name="cmd">String in format John Toll//42</param>
        public void AddPerson(string cmd)
        {
            string[] data;
            try
            {
                data = cmd.Split(new [] { "//"}, StringSplitOptions.None );
            }
            catch
            {
                throw new ArgumentException("Argument must be in format John Toll//42");
            }

            Person person;
            try
            {
                var name = data[0];
                var age = int.Parse(data[1]);
                person = new Person(name, age);
            }
            catch (ArgumentException arEx)
            {
                throw new ArgumentException(arEx.Message);
            }
            Collection.Add(person);
        }

        /// <summary>
        /// Exits the app
        /// </summary>
        public static void Quit()
        {
            Environment.Exit(0);
        }
    }
}
