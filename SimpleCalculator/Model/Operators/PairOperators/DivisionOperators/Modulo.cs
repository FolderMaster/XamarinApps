namespace SimpleCalculator.Model.Operators.PairOperators.DivisionOperators
{
    public class Modulo : BasicDivisionOperator
    {
        public override int Priority => 1;

        public override string Symbol => "÷";

        protected override double CalculateDivisionValue()
        {
            var rightValue = RightOperand.GetValue();
            var divisionValue = LeftOperand.GetValue() / rightValue;
            return (divisionValue - (int)divisionValue) * rightValue;
        }
    }
}