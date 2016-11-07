using System;
using System.Linq;

namespace CalculatorWithDelegates.Calculator
{
    public class Result
    {
        delegate int Cmd();

        private Cmd cmd;

        private readonly Params _parameters;

        public Result(Params parameters)
        {
            _parameters = parameters;
            cmd = null;
            switch (_parameters.Operator)
            {
                case Type.Operator.Substract:
                    cmd += Substract;
                    break;
                case Type.Operator.Multiply:
                    cmd += Multiply;
                    break;
                case Type.Operator.Plus:
                    cmd += Plus;
                    break;
                default:
                    throw new NotImplementedException($"This operator {Type.OperatorString[_parameters.Operator]} is not implemented");
            }
        }

        protected int Substract()
        {
            var result = _parameters.Operants[0];
            for (var i = 1; i < _parameters.Operants.Length; i++)
            {
                result -= _parameters.Operants[i];
            }
            return result;
        }

        protected int Multiply()
        {
            var result = _parameters.Operants[0];
            for (var i = 1; i < _parameters.Operants.Length; i++)
            {
                result *= _parameters.Operants[i];
            }
            return result;
        }

        protected int Plus()
        {
            var result = _parameters.Operants[0];
            for (var i = 1; i < _parameters.Operants.Length; i++)
            {
                result += _parameters.Operants[i];
            }
            return result;
        }

        public override string ToString()
        {
            return cmd().ToString();
        }
    }
}
