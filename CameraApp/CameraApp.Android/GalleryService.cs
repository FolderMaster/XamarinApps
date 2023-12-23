using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using System.IO;

namespace CameraApp.Droid
{
    public class GalleryService : IGalleryService
    {
        public void OpenGallery()
        {
            var context = Application.Context;
            var intent = new Intent(Intent.ActionView);
            intent.AddFlags(ActivityFlags.NewTask);
            intent.SetType("image/*");
            intent.SetAction(Intent.ActionGetContent);
            context.StartActivity(intent);
        }

        public async void SaveToGallery(string name, string path)
        {
            var dcimPath = Environment.GetExternalStoragePublicDirectory
                (Environment.DirectoryDcim).AbsolutePath;
            var destinationPath = Path.Combine(dcimPath, name);
            File.Copy(path, destinationPath);
            MediaScannerConnection.ScanFile(Application.Context, new string[] { destinationPath },
                null, null);
        }
    }
}