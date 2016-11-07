using System;
using System.Collections.Generic;
using System.Linq;

namespace Sorter
{
    public class Program
    {
        private readonly ILogger _console;

        public Program(ILogger console)
        {
            _console = console;
        }

        static void Main(string[] args)
        {
            var console = new ConsoleLogger();
            var program = new Program(console);

            var inputNums = new int[0];
            do
            {
                try
                {
                    inputNums = program.EnterArray();
                }
                catch (Exception e)
                {
                    console.WriteLine(e.Message);
                    inputNums = new int[0];
                }
            } while (inputNums.Length < 1);

            //sort
            var bubbleSorter = new Bubble();
            var selectionSorter = new Selection();
            var bubbleSorted = bubbleSorter.Order(inputNums);
            var selectionSorted = selectionSorter.Order(inputNums);
            //print sorted ints by Bubble Sort
            console.WriteLine("Sorted by Bubble Sort:");
            program.PrintArray(bubbleSorted);
            //print sorted ints by Selection Sort
            console.WriteLine("Sorted by Selection Sort:");
            program.PrintArray(selectionSorted);
        }

        /// <summary>
        /// Enters a string and returns an array with ints
        /// </summary>
        /// <returns>Array with ints</returns>
        public int[] EnterArray()
        {
            _console.Write("Enter array in format x,y,z...:");

            var input = _console.ReadLine();
            var inputNums = input.Split(',').ToArray().Select(e =>
            {
                var num = 0;
                try
                {
                    num = int.Parse(e);
                }
                catch
                {
                    throw new Exception("Use format x,y,z. Example: 5,1,3");
                }
                return num;
            }).ToArray();

            return inputNums;
        }

        private void PrintArray(IEnumerable<int> arr)
        {
            _console.WriteLine(string.Join(",", arr));
        }
    }
    
}
