namespace SimpleCalculator.Model.Operators.PairOperators
{
    public abstract class BasicPairOperator<T> : IPairOperator<T>
    {
        private IValue<T> _leftOperand;

        private IValue<T> _rightOperand;

        public IValue<T> Parent { get; set; }

        public int Index { get; set; }

        public abstract int Priority { get; }

        public abstract string Symbol { get; }

        public IValue<T> LeftOperand
        {
            get => _leftOperand;
            set => _leftOperand = value;
        }

        public IValue<T> RightOperand
        {
            get => _rightOperand;
            set => _rightOperand = value;
        }

        public abstract T GetValue();
    }
}