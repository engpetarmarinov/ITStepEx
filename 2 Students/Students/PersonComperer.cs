using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Students
{
    public class PersonComperer : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            if (x.Name.Length < y.Name.Length)
            {
                return -1;
            } else if (x.Name.Length == y.Name.Length)
            {
                return 0;
            }
            return 1;
        }
    }
}
