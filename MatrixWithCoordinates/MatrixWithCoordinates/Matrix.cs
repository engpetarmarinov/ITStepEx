using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixWithCoordinates
{   

    class Matrix
    {        
        private int Cols { get; set; }

        private int[][] matrix;

        public void AskForRows()
        {
            Console.Write("Enter rows:");
            int rows;
            Int32.TryParse(Console.ReadLine(), out rows);
            matrix = new int[rows][];            
        }

        public void AskForCols()
        {
            Console.Write("Enter coloms:");
            int cols;
            Int32.TryParse(Console.ReadLine(), out cols);
            Cols = cols;
        }

        public int[] AskForElement()
        {
            Console.Write("Enter element indexes(Example: 1 2):");
            var input = Console.ReadLine();
            int[] parameters = ParseParams(input);
            return parameters;
        }

        private static int[] ParseParams(string input)
        {
            var strings = input.Trim().Split();
            return Array.ConvertAll(strings, s => int.Parse(s));
        }

        public void GenerateValues()
        {
            var i = 1;
            for (var row = 0; row < matrix.Length; row++)
            {
                matrix[row] = new int[Cols];
                for (var col = 0; col < Cols; col++)
                {
                    matrix[row][col] = i++;
                }
            }
        }

        public void IncrementCoordinates(int[] indexes)
        {
            int row = indexes[0];
            int col = indexes[1];
            matrix[row][col]++;
        }

        public override string ToString()
        {
            var line = "";
            foreach (int[] row in matrix)
            {
                foreach (int el in row)
                {
                    line += $"{el.ToString()}\t";

                }
                line += "\n";
            }
            return line;
        }
    }
}
