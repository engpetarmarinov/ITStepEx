using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    class Program
    {
        static void Main(string[] args)
        {
            var myList = new ListGeneric<int>();
            myList.Add(2);
            myList.Add(2);
            myList.RemoveAt(1);

            myList[0] = 3;
            myList[1] = 3;

        }
    }
}
