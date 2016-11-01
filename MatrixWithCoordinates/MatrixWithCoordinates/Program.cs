using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixWithCoordinates
{   

    class Program
    {
        static void Main(string[] args)
        {
            var matrix = new Matrix();
            matrix.AskForRows();
            matrix.AskForCols();
            matrix.GenerateValues();
            Console.WriteLine(matrix);
            int[] indexes = matrix.AskForElement();
            matrix.IncrementCoordinates(indexes);
            Console.WriteLine(matrix);
        }
    }
}
