using System;

namespace SimpleCalculator.Model.Operators.SingleOperators
{
    public class Root : BasicSingleOperator<double>
    {
        public override int Priority => 0;

        public override string Symbol => "√";

        public override double GetValue() => Math.Sqrt(Operand.GetValue());
    }
}