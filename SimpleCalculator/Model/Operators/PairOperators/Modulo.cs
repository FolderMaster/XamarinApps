namespace SimpleCalculator.Model.Operators.PairOperators
{
    internal class Modulo : BasicPairOperator<double>
    {
        public override int Priority => 1;

        public override string Symbol => "÷";

        public override double GetValue()
        {
            var leftValue = LeftOperand.GetValue();
            var divisionValue = leftValue / RightOperand.GetValue();
            return (divisionValue - (int)divisionValue) * leftValue;
        }
    }
}