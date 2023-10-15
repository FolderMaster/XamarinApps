namespace SimpleCalculator.Model.Variables
{
    public interface IVariable<T> : IValue<T>
    {
        public void SetValue(T value);
    }
}