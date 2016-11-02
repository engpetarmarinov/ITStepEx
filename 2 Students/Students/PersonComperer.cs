using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students
{
    public class PersonComperer : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            var xFirstName = GetFirstName(x.Name);
            var yFirstName = GetFirstName(y.Name);

            if (xFirstName.Length < yFirstName.Length)
            {
                return -1;
            } else if (xFirstName.Length == yFirstName.Length)
            {
                return 0;
            }
            return 1;
        }

        public string GetFirstName(string name)
        {
            var nameParts = name.Split(' ');
            return nameParts[0];
        }
    }
}
