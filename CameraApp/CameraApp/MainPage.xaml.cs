using System.ComponentModel;
using Xamarin.Forms;

namespace CameraApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var viewModel = new MainViewModel();
            viewModel.PropertyChanged += ViewModel_PropertyChanged;
            BindingContext = viewModel;
        }

        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(MainViewModel.ErrorMessage))
            {
                DisplayAlert("Сообщение об ошибке", ((MainViewModel)sender).ErrorMessage, "OK");
            }
        }
    }
}
