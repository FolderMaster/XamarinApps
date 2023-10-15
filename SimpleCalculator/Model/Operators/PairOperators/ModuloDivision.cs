namespace SimpleCalculator.Model.Operators.PairOperators
{
    public class ModuloDivision : BasicPairOperator<double>
    {
        public override int Priority => 1;

        public override string Symbol => "/";

        public override double GetValue() =>
            (int)(LeftOperand.GetValue() / RightOperand.GetValue());
    }
}