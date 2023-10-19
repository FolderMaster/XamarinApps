using System;

namespace SimpleCalculator.Model.Operators.PairOperators.DivisionOperators
{
    public abstract class BasicDivisionOperator : BasicPairOperator<double>
    {
        protected abstract double CalculateDivisionValue();

        protected override double CalculateValue()
        {
            if (RightOperand.GetValue() == 0)
            {
                throw new ArgumentException($"Нельзя делить на 0!");
            }
            return CalculateDivisionValue();
        }
    }
}