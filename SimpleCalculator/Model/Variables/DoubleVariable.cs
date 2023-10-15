namespace SimpleCalculator.Model.Variables
{
    public class DoubleVariable : IVariable<double>
    {
        protected double _value;

        public IValue<double> Parent { get; set; }

        public int Index { get; set; }

        public int Priority => -1;

        public string Symbol => _value.ToString();

        public double GetValue() => _value;

        public void SetValue(double value) => _value = value;

        public DoubleVariable() { }

        public DoubleVariable(double value) => _value = value;
    }
}