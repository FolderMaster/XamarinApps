using System.Collections;
using System.Collections.Generic;

namespace SimpleCalculator.Model.Expressions
{
    public class ExpressionEnumerator<T> : IEnumerator<IValue<T>>
    {
        protected List<IValue<T>> _values = new List<IValue<T>>();

        protected int _position = -1;

        public IValue<T> Current => _values[_position];

        object IEnumerator.Current => Current;

        public ExpressionEnumerator(IValue<T> value)
        {
            var stack = new Stack<IValue<T>>();
            var current = value;

            while (current != null || stack.Count > 0)
            {
                if(current != null)
                {
                    stack.Push(current);
                    current = ExpressionHelper<T>.GetLeftValue(current);
                }
                else if(stack.Count > 0)
                {
                    current = stack.Pop();
                    _values.Add(current);
                    current = ExpressionHelper<T>.GetRightValue(current);
                }
            }
        }

        public bool MoveNext()
        {
            if(_position < _values.Count)
            {
                ++_position;
            }
            return _position >= 0 && _position < _values.Count;
        }

        public void Reset() => _position = -1;

        public void Dispose() { }
    }
}