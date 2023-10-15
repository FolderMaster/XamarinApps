namespace SimpleCalculator.Model.Operators.PairOperators
{
    public interface IPairOperator<T> : IOperator<T>
    {
        public IValue<T> LeftOperand { get; set; }

        public IValue<T> RightOperand { get; set; }
    }
}