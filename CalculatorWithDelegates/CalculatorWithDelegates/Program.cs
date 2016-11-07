using System;

namespace CalculatorWithDelegates
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = new Calculator.Parser();
            
            try
            {
                var parameters = parser.Parse(Console.ReadLine());
                var result = new Calculator.Result(parameters);
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }
}
