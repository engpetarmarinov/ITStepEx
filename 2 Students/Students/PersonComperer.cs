using System.Collections.Generic;

namespace Students
{
    public class PersonComperer : IComparer<Person>
    {
        /// <summary>
        /// Compare 2 persons by name
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>Comparison number</returns>
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

        /// <summary>
        /// Get the first namae of a person
        /// </summary>
        /// <param name="name"></param>
        /// <returns>The first name</returns>
        public string GetFirstName(string name)
        {
            var nameParts = name.Split(' ');
            return nameParts[0];
        }
    }
}
