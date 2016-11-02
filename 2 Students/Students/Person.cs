using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Students
{
    public class Person
    {
        public string Name { get; set; }
        public int? Age { get; set; }

        private void Construct()
        {
            Name = this.Name ?? "No Name";
            Age = this.Age ?? 1;
            if (Age < 0)
            {
                throw new ArgumentException("Value of Age must be possitive number.");
            }
        }

        public Person()
        {
            Construct();
        }

        public Person(string name)
        {
            Name = name;
            Construct();
        }

        public Person(int age)
        {
            
            Age = age;
            Construct();
        }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
            Construct();
        }

    }
}
