using System;
using System.Collections.Generic;

namespace _2_Students
{
    public class People
    {
        private const int AgeLimit = 18;

        public List<Person> Collection { get; private set; } = new List<Person>();

        public void Read()
        {
            while (true)
            {
                Console.Write("Enter person name//age or 'quit':");
                var command = Console.ReadLine()?.Trim();
                ParseCommand(command);
            }
        }

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

        private void PrintAll()
        {
            Collection.Sort(new PersonComperer());

            foreach (var person in Collection)
            {
                if (person.Age >= AgeLimit)
                {
                    Console.WriteLine($"{person.Name} is {person.Age} years old.");
                }
            }
        }

        public void AddPerson(string cmd)
        {
            string[] data;
            try
            {
                data = cmd.Split(new string[] { "//"}, StringSplitOptions.None );
            }
            catch (Exception e)
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

        public static void Quit()
        {
            Environment.Exit(0);
        }
    }
}