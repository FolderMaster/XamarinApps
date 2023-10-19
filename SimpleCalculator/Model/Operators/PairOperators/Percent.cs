namespace SimpleCalculator.Model.Operators.PairOperators
{
    public class Percent : BasicPairOperator<double>
    {
        public override int Priority => 0;

        public override string Symbol => "%";

        protected override double CalculateValue() =>
            LeftOperand.GetValue() / 100d * RightOperand.GetValue();
    }
}