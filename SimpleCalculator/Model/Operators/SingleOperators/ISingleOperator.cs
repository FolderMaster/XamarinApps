namespace SimpleCalculator.Model.Operators.SingleOperators
{
    public interface ISingleOperator<T> : IOperator<T>
    {
        public IValue<T> Operand { get; set; }
    }
}