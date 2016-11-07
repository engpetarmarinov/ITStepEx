using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace CalculatorWithDelegates.Calculator
{
    public class Parser
    {
        public Params Parse(string input)
        {
            var calcType = new Type();
            var operatorsPat = string.Join("",calcType.OperatorString.Select(o => "\\" + o.Value));
            var pat = @"(\d+)\s?([" + operatorsPat  + @"])\s?(\d+)";

            // Instantiate the regular expression object.
            var r = new Regex(pat, RegexOptions.IgnoreCase);

            // Match the regular expression pattern against a text string.
            var m = r.Match(input);

            if (m.Groups.Count != 4)
            {
                throw new ArgumentException("Format x operator y!");
            }

            var operant1 = m.Groups[1].Captures[0].Value;
            var operation = m.Groups[2].Captures[0].Value;
            var operant2 = m.Groups[3].Captures[0].Value;

            return new Params() {
                Operator = calcType.GetOperator(operation),
                Operants = new int[] { int.Parse(operant1), int.Parse(operant2) }
            };
        }
    }
}
