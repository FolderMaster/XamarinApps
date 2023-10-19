namespace SimpleCalculator.Model.Operators.PairOperators
{
    public class Multiplication : BasicPairOperator<double>
    {
        public override int Priority => 1;

        public override string Symbol => "×";

        protected override double CalculateValue() =>
            LeftOperand.GetValue() * RightOperand.GetValue();
    }
}