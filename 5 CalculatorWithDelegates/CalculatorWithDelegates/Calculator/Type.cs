using System.Collections.Generic;
using System.Linq;

namespace CalculatorWithDelegates.Calculator
{
    public class Type
    {
        public enum Operator
        {
            Substract,
            Multiply,
            Plus,
            Module,
            Divide,
            Power
        }

        public static Dictionary<Operator, string> OperatorString = new Dictionary<Operator, string>()
        {
            { Operator.Substract, "-"},
            { Operator.Plus, "+"},
            { Operator.Multiply, "*" },
            { Operator.Module, "%" },
            { Operator.Divide, "/" },
            { Operator.Power, "^" }
        };

        public static Operator GetOperator(string str)
        {
            return OperatorString.FirstOrDefault(x => x.Value == str).Key;
        }
    }
}