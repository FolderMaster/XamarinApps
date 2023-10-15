﻿namespace SimpleCalculator.Model.Operators.PairOperators
{
    public class Addition : BasicPairOperator<double>
    {
        public override int Priority => 2;

        public override string Symbol => "+";

        public override double GetValue() => LeftOperand.GetValue() + RightOperand.GetValue();
    }
}