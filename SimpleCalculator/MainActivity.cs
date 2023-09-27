using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using Android.Content.PM;
using Xamarin.Essentials;

namespace SimpleCalculator
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            //var firstNumberEditText = FindViewById<EditText>(Resource.Id.firstNumberEditText);
            //var secondNumberEditText = FindViewById<EditText>(Resource.Id.secondNumberEditText);
            //var button = FindViewById<Button>(Resource.Id.button);
            //var resultTextView = FindViewById<TextView>(Resource.Id.resultTextView);

            //button.Click += (sender, e) =>
            //{
            //    var firstNumber = double.Parse(firstNumberEditText.Text);
            //    var secondNumber = double.Parse(secondNumberEditText.Text);
            //    resultTextView.Text = (firstNumber + secondNumber).ToString();
            //};
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions,
            [GeneratedEnum] Permission[] grantResults)
        {
            Platform.OnRequestPermissionsResult(requestCode, permissions,
                grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}