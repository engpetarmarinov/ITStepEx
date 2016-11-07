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
            Plus
        }

        public Dictionary<Operator, string> OperatorString = new Dictionary<Operator, string>();

        public Type()
        {
            OperatorString.Add(Operator.Substract, "-");
            OperatorString.Add(Operator.Plus, "+");
            OperatorString.Add(Operator.Multiply, "*");
        }

        public Operator GetOperator(string str)
        {
            return OperatorString.FirstOrDefault(x => x.Value == str).Key;
        }
    }
}