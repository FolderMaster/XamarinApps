namespace SimpleCalculator.Model.Operators.PairOperators
{
    public class Subtraction : BasicPairOperator<double>
    {
        public override int Priority => 2;

        public override string Symbol => "-";

        protected override double CalculateValue() =>
            LeftOperand.GetValue() - RightOperand.GetValue();
    }
}