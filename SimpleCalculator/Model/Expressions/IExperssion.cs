using System.Collections.Generic;

namespace SimpleCalculator.Model.Expressions
{
    public interface IExpression<T> : IValue<T>, IEnumerable<IValue<T>>
    {
        public int Count { get; }

        public IValue<T> this[int index] { get; }

        public void Add(IValue<T> value);

        public void Add(IValue<T> value, int index);

        public void Remove(int index);

        public void Clear();
    }
}