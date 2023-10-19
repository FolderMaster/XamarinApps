using System;

using SimpleCalculator.Model.Expressions;
using SimpleCalculator.Model.Operators.PairOperators;
using SimpleCalculator.Model.Operators.SingleOperators;
using SimpleCalculator.Model.Variables;

namespace SimpleCalculator
{
    public class NumberCalculatorManager
    {
        private const char _equalSymbol = '=';

        private const char _pointSymbol = '.';

        protected IExpression<double> _expression;

        protected bool _hasUnmarkedPoint = false;

        public NumberCalculatorManager(IExpression<double> expression) => _expression = expression;

        protected void ParseValueToVariable(string value, IVariable<double> variable)
        {
            var doubleValue = 0d;
            if (double.TryParse(value, out doubleValue))
            {
                variable.SetValue(doubleValue);
            }
        }

        protected void RemoveLastValue()
        {
            var count = _expression.Count;
            _expression.Remove(count - 1);
            if (count == 1)
            {
                _expression.Add(new DoubleVariable());
            }
        }

        public void AddNumber(int number)
        {
            var count = _expression.Count;
            if (count != 0)
            {
                if (_expression[count - 1] is IVariable<double> variable)
                {
                    var value = variable.GetValue().ToString();
                    if(_hasUnmarkedPoint)
                    {
                        value += _pointSymbol;
                        _hasUnmarkedPoint = false;
                    }
                    value += number.ToString();
                    ParseValueToVariable(value, variable);
                }
                else
                {
                    _expression.Add(new DoubleVariable(number));
                }
            }
            else
            {
                _expression.Add(new DoubleVariable(number));
            }
        }

        public void AddPoint()
        {
            var count = _expression.Count;
            if (count != 0)
            {
                if (_expression[count - 1] is IVariable<double> variable)
                {
                    var value = variable.GetValue().ToString();
                    var index = value.IndexOf(_pointSymbol);
                    if (index != -1)
                    {
                        value = value.Remove(index, 1);
                    }
                    ParseValueToVariable(value, variable);
                }
                else
                {
                    _expression.Add(new DoubleVariable());
                }
            }
            _hasUnmarkedPoint = true;
        }

        public void AddSingleOperator(ISingleOperator<double> singleOperator)
        {
            var count = _expression.Count;
            var index = 0;
            if(count != 0)
            {
                if(_expression[count - 1] is IVariable<double>)
                {
                    index = count - 1;
                }
                else
                {
                    index = count;
                }
            }
            _expression.Add(singleOperator, index);
            _hasUnmarkedPoint = false;
        }

        public void AddPairOperator(IPairOperator<double> pairOperator)
        {
            var count = _expression.Count;
            if (count != 0)
            {
                if (_expression[count - 1] is IPairOperator<double>)
                {
                    _expression.Remove(count - 1);
                }
            }
            _expression.Add(pairOperator);
            _hasUnmarkedPoint = false;
        }

        public void DeleteFull()
        {
            _expression.Clear();
            _expression.Add(new DoubleVariable());
            _hasUnmarkedPoint = false;
        }

        public void DeletePart()
        {
            var count = _expression.Count;
            if(count != 0)
            {
                if (count == 1 && _expression[count - 1] is IVariable<double> variable)
                {
                    variable.SetValue(0);
                }
                else
                {
                    RemoveLastValue();
                }
            }
            _hasUnmarkedPoint = false;
        }

        public void DeleteSingle()
        {
            var count = _expression.Count;
            if (count != 0)
            {
                if (_expression[count - 1] is IVariable<double> variable)
                {
                    if(_hasUnmarkedPoint)
                    {
                        _hasUnmarkedPoint = false;
                    }
                    else
                    {
                        var value = variable.GetValue().ToString();
                        var length = value.Length;
                        if (length > 1)
                        {
                            value = value.Remove(length - 1);
                            if (value[value.Length - 1] == _pointSymbol)
                            {
                                _hasUnmarkedPoint = true;
                            }
                            ParseValueToVariable(value, variable);
                        }
                        else if (count == 1)
                        {
                            variable.SetValue(0);
                        }
                        else
                        {
                            _expression.Remove(count - 1);
                        }
                    }
                }
                else
                {
                    RemoveLastValue();
                }
            }
        }

        public void SetValue()
        {
            try
            {
                var result = _expression.GetValue();
                _expression.Clear();
                _expression.Add(new DoubleVariable(result));
                _hasUnmarkedPoint = false;
            }
            catch { }
        }

        public string GetExpressionString()
        {
            var result = _expression.Symbol;
            if(_hasUnmarkedPoint)
            {
                result += _pointSymbol;
            }
            return result;
        }

        public string GetValueString()
        {
            var result = "";
            try
            {
                result = _equalSymbol + _expression.GetValue().ToString();
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }
    }
}