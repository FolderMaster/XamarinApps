using System;
using System.Collections;
using System.Collections.Generic;

namespace SimpleCalculator.Model.Expressions
{
    public class Expression<T> : IExpression<T>
    {
        protected IValue<T> _root = null;
        
        public IValue<T> Parent { get; set; }

        public int Index { get; set; }

        public int Priority => -1;

        public int Count { get; private set; }

        public string Symbol
        {
            get
            {
                var result = "";
                foreach (var item in this)
                {
                    result += item.Symbol;
                }
                return result;
            }
        }

        public IValue<T> this[int index] => FindValue(index);

        protected IValue<T> Merge(IValue<T> left, IValue<T> right)
        {
            if(left == null)
            {
                return right;
            }
            else if(right == null)
            {
                return left;
            }
            else if(left.Priority >= right.Priority)
            {
                ExpressionHelper<T>.SetRightValue(left,
                    Merge(ExpressionHelper<T>.GetRightValue(left), right));
                return left;
            }
            else
            {
                ExpressionHelper<T>.SetLeftValue(right,
                    Merge(left, ExpressionHelper<T>.GetLeftValue(right)));
                return right;
            }
        }

        protected (IValue<T>, IValue<T>) Split(IValue<T> value, int index)
        {
            if(value == null)
            {
                return (null, null);
            }
            else if(value.Index < index)
            {
                var (left, right) = Split(ExpressionHelper<T>.GetRightValue(value), index);
                ExpressionHelper<T>.SetRightValue(value, left);
                return (value, right);
            }
            else
            {
                var (left, right) = Split(ExpressionHelper<T>.GetLeftValue(value), index);
                ExpressionHelper<T>.SetLeftValue(value, right);
                return (left, value);
            }
        }

        protected void ChangeIndexes(IValue<T> value, int change)
        {
            if (value != null)
            {
                value.Index += change;
                ChangeIndexes(ExpressionHelper<T>.GetLeftValue(value), change);
                ChangeIndexes(ExpressionHelper<T>.GetRightValue(value), change);
            }
        }

        public IValue<T> FindValue(int index)
        {
            var current = _root;
            while (current != null)
            {
                if(current.Index == index)
                {
                    return current;
                }
                else
                {
                    current = (current.Index < index) switch
                    {
                        true => ExpressionHelper<T>.GetRightValue(current),
                        false => ExpressionHelper<T>.GetLeftValue(current)
                    };

                    if(current == null)
                    {
                        break;
                    }
                }
            }
            throw new ArgumentException();
        }

        public void Add(IValue<T> value) => Add(value, Count);

        public void Add(IValue<T> value, int index)
        {
            value.Index = index;
            var (left, right) = Split(_root, index);
            ChangeIndexes(right, 1);
            _root = Merge(Merge(left, value), right);
            ++Count;
        }

        public void Remove(int index)
        {
            var (left, rightLeft) = Split(_root, index);
            var (_, right) = Split(rightLeft, index + 1);
            ChangeIndexes(right, -1);
            _root = Merge(left, right);
            --Count;
        }

        public void Clear() => _root = null;

        public T GetValue() => _root.GetValue();

        public IEnumerator<IValue<T>> GetEnumerator() =>
            new ExpressionEnumerator<T>(_root);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}