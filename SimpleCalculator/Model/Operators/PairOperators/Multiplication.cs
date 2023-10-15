namespace SimpleCalculator.Model.Operators.PairOperators
{
    public class Multiplication : BasicPairOperator<double>
    {
        public override int Priority => 1;

        public override string Symbol => "×";

        public override double GetValue() => LeftOperand.GetValue() * RightOperand.GetValue();
    }
}