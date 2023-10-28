using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Widget;
using AndroidX.AppCompat.App;

using System;
using System.Runtime.CompilerServices;

namespace CustomViewApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private ViewsContainer _container;

        private void ShowActivityState([CallerMemberName] string? stateName = null) =>
            Log.Info("ActivityState", stateName);

        protected override void OnResume()
        {
            base.OnResume();
            ShowActivityState();
        }

        protected override void OnStart()
        {
            base.OnStart();
            ShowActivityState();
        }

        protected override void OnPause()
        {
            base.OnPause();
            ShowActivityState();
        }

        protected override void OnStop()
        {
            base.OnStop();
            ShowActivityState();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            ShowActivityState();
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);
            ShowActivityState();
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            ShowActivityState();

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            var button = FindViewById<Button>(Resource.Id.button);
            button.Click += Button_Click;
            _container = FindViewById<ViewsContainer>(Resource.Id.container);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions,
            [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions,
                grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private void Button_Click(object sender, EventArgs e)
        {
            _container.IncrementViews();
        }
    }
}