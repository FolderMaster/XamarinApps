namespace SimpleCalculator.Model
{
    public interface IValue<T>
    {
        public IValue<T> Parent { get; set; }

        public int Index { get; set; }

        public int Priority { get; }

        public string Symbol { get; }

        public T GetValue();
    }
}