using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using Android.Content.PM;
using Xamarin.Essentials;
using System.Collections.Generic;
using System;

using SimpleCalculator.Model.Expressions;
using SimpleCalculator.Model.Operators.PairOperators;
using SimpleCalculator.Model.Operators.SingleOperators;
using SimpleCalculator.Model.Variables;

namespace SimpleCalculator
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private TextView _expressionTextView;

        private TextView _resultTextView;

        private NumberCalculatorManager _calculator;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            _expressionTextView = FindViewById<TextView>(Resource.Id.expressionTextView);
            _resultTextView = FindViewById<TextView>(Resource.Id.resultTextView);

            var singleDeletionButton = FindViewById<Button>(Resource.Id.singleDeletionButton);
            var partDeletionButton = FindViewById<Button>(Resource.Id.partDeletionButton);
            var fullDeletionButton = FindViewById<Button>(Resource.Id.fullDeletionButton);
            var oneButton = FindViewById<Button>(Resource.Id.oneButton);
            var twoButton = FindViewById<Button>(Resource.Id.twoButton);
            var threeButton = FindViewById<Button>(Resource.Id.threeButton);
            var fourButton = FindViewById<Button>(Resource.Id.fourButton);
            var fiveButton = FindViewById<Button>(Resource.Id.fiveButton);
            var sixButton = FindViewById<Button>(Resource.Id.sixButton);
            var sevenButton = FindViewById<Button>(Resource.Id.sevenButton);
            var eightButton = FindViewById<Button>(Resource.Id.eightButton);
            var nineButton = FindViewById<Button>(Resource.Id.nineButton);
            var zeroButton = FindViewById<Button>(Resource.Id.zeroButton);
            var additionButton = FindViewById<Button>(Resource.Id.additionButton);
            var subtractionButton = FindViewById<Button>(Resource.Id.subtractionButton);
            var multiplicationButton = FindViewById<Button>(Resource.Id.multiplicationButton);
            var divisionButton = FindViewById<Button>(Resource.Id.divisionButton);
            var moduloButton = FindViewById<Button>(Resource.Id.moduloButton);
            var moduloDivisionButton = FindViewById<Button>(Resource.Id.moduloDivisionButton);
            var percentButton = FindViewById<Button>(Resource.Id.percentButton);
            var rootButton = FindViewById<Button>(Resource.Id.rootButton);
            var equationButton = FindViewById<Button>(Resource.Id.equationButton);
            var pointButton = FindViewById<Button>(Resource.Id.pointButton);

            var deletionsDictionary = new Dictionary<Button, Action>()
            {
                [singleDeletionButton] = () => _calculator.DeleteSingle(),
                [partDeletionButton] = () => _calculator.DeletePart(),
                [fullDeletionButton] = () => _calculator.DeleteFull(),
                [equationButton] = () => _calculator.SetValue(),
                [pointButton] = () => _calculator.AddPoint()
            };
            foreach (var (button, function) in deletionsDictionary)
            {
                button.Click += (sender, e) => ExecuteCalculatorFunction(function);
            }

            var numberButtons = new List<Button>()
            {
                zeroButton, oneButton, twoButton, threeButton, fourButton,
                fiveButton, sixButton, sevenButton, eightButton, nineButton
            };
            for (var i = 0; i < numberButtons.Count; ++i)
            {
                var number = i;
                numberButtons[i].Click += (sender, e) => ExecuteCalculatorFunction(() =>
                    _calculator.AddNumber(number));
            }

            var pairOperatorsDictionary = new Dictionary<Button, Func<IPairOperator<double>>>()
            {
                [additionButton] = () => new Addition(),
                [subtractionButton] = () => new Subtraction(),
                [multiplicationButton] = () => new Multiplication(),
                [divisionButton] = () => new Division(),
                [moduloButton] = () => new Modulo(),
                [moduloDivisionButton] = () => new ModuloDivision(),
                [percentButton] = () => new Percent()
            };
            foreach (var (button, function) in pairOperatorsDictionary)
            {
                button.Click += (sender, e) => ExecuteCalculatorFunction(() =>
                    _calculator.AddPairOperator(function()));
            }

            var singleOperatorsDictionary = new Dictionary<Button, Func<ISingleOperator<double>>>()
            {
                [rootButton] = () => new Root()
            };
            foreach (var (button, function) in singleOperatorsDictionary)
            {
                button.Click += (sender, e) => ExecuteCalculatorFunction(() =>
                    _calculator.AddSingleOperator(function()));
            }

            var expression = new Expression<double>();
            expression.Add(new DoubleVariable());
            _calculator = new NumberCalculatorManager(expression);
            ExecuteCalculatorFunction(() => { });
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions,
            [GeneratedEnum] Permission[] grantResults)
        {
            Platform.OnRequestPermissionsResult(requestCode, permissions,
                grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private void ExecuteCalculatorFunction(Action function)
        {
            function();
            _expressionTextView.Text = _calculator.GetExpressionString();
            _resultTextView.Text = _calculator.GetValueString();
        }
    }
}