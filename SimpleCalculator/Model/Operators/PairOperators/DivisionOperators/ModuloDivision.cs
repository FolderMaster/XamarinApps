namespace SimpleCalculator.Model.Operators.PairOperators.DivisionOperators
{
    public class ModuloDivision : BasicDivisionOperator
    {
        public override int Priority => 1;

        public override string Symbol => "/";

        protected override double CalculateDivisionValue() =>
            (int)(LeftOperand.GetValue() / RightOperand.GetValue());
    }
}