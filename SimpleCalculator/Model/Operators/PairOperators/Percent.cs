namespace SimpleCalculator.Model.Operators.PairOperators
{
    public class Percent : BasicPairOperator<double>
    {
        public override int Priority => 0;

        public override string Symbol => "%";

        public override double GetValue() =>
            LeftOperand.GetValue() / 100d * RightOperand.GetValue();
    }
}