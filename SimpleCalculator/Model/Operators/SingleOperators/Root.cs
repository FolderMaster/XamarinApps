using System;

namespace SimpleCalculator.Model.Operators.SingleOperators
{
    public class Root : BasicSingleOperator<double>
    {
        public override int Priority => 0;

        public override string Symbol => "√";

        protected override double CalculateValue() => Math.Sqrt(Operand.GetValue());
    }
}