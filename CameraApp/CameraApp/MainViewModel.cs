using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace CameraApp
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private ImageSource _image = null;

        private string _imagePath;

        private string _imageName;

        private string _errorMessage = null;

        private bool _isPickedImage = false;

        public ImageSource Image
        {
            get => _image;
            private set
            {
                if(value != Image)
                {
                    _image = value;
                    IsPickedImage = Image != null;
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(Image)));
                }
            }
        }

        public bool IsPickedImage
        {
            get => _isPickedImage;
            private set
            {
                if (value != IsPickedImage)
                {
                    _isPickedImage = value;
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(IsPickedImage)));
                }
            }
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            private set
            {
                _errorMessage = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(ErrorMessage)));
            }
        }

        public ICommand ShowGalleryCommand { get; private set; }

        public ICommand SavePhotoCommand { get; private set; }

        public ICommand PickPhotoCommand { get; private set; }

        public MainViewModel()
        {
            PickPhotoCommand = new Command(() => PickPhotoAsync());
            SavePhotoCommand = new Command(() => SavePhoto());
            ShowGalleryCommand = new Command(() => ShowGallery());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void ShowGallery()
        {
            try
            {
                DependencyService.Get<IGalleryService>().OpenGallery();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        private void SavePhoto()
        {
            try
            {
                DependencyService.Get<IGalleryService>().SaveToGallery(_imageName, _imagePath);
                Image = null;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        private async void PickPhotoAsync()
        {
            try
            {
                var photo = await MediaPicker.CapturePhotoAsync(new MediaPickerOptions
                {
                    Title = $"Xamarin.{DateTime.Now.ToString("dd.MM.yyyy_hh.mm.ss")}.png"
                });
                _imageName = photo.FileName;

                var newFile = Path.Combine(FileSystem.AppDataDirectory, _imageName);
                using (var stream = await photo.OpenReadAsync())
                {
                    using (var newStream = File.OpenWrite(newFile))
                    {
                        await stream.CopyToAsync(newStream);
                    }
                }
                _imagePath = photo.FullPath;

                Image = ImageSource.FromFile(_imagePath);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
    }
}
