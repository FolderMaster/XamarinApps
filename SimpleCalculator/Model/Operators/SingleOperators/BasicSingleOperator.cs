namespace SimpleCalculator.Model.Operators.SingleOperators
{
    public abstract class BasicSingleOperator<T> : ISingleOperator<T>
    {
        private IValue<T> _operand;

        public IValue<T> Parent { get; set; }

        public int Index { get; set; }

        public abstract int Priority { get; }

        public abstract string Symbol { get; }

        public IValue<T> Operand
        {
            get => _operand;
            set => _operand = value;
        }

        public abstract T GetValue();
    }
}