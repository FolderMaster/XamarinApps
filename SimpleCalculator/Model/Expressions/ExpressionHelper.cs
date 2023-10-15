using SimpleCalculator.Model.Operators.PairOperators;
using SimpleCalculator.Model.Operators.SingleOperators;

namespace SimpleCalculator.Model.Expressions
{
    public static class ExpressionHelper<T>
    {
        public static IValue<T> GetRightValue(IValue<T> value)
        {
            return (value) switch
            {
                ISingleOperator<T> singleOperator => singleOperator.Operand,
                IPairOperator<T> pairOperator => pairOperator.RightOperand,
                _ => null
            };
        }

        public static void SetRightValue(IValue<T> parent, IValue<T> value)
        {
            switch (parent)
            {
                case ISingleOperator<T> singleOperator: singleOperator.Operand = value; break;
                case IPairOperator<T> pairOperator: pairOperator.RightOperand = value; break;
            };
        }

        public static IValue<T> GetLeftValue(IValue<T> value)
        {
            return (value) switch
            {
                IPairOperator<T> pairOperator => pairOperator.LeftOperand,
                _ => null
            };
        }

        public static void SetLeftValue(IValue<T> parent, IValue<T> value)
        {
            switch (parent)
            {
                case IPairOperator<T> pairOperator: pairOperator.LeftOperand = value; break;
            };
        }
    }
}