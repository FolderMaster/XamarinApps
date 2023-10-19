namespace SimpleCalculator.Model.Operators.PairOperators.DivisionOperators
{
    public class Division : BasicDivisionOperator
    {
        public override int Priority => 1;

        public override string Symbol => ":";

        protected override double CalculateDivisionValue() =>
            LeftOperand.GetValue() / RightOperand.GetValue();
    }
}