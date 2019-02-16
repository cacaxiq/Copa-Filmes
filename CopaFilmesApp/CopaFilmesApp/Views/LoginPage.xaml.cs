using CopaFilmesApp.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CopaFilmesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
    {
        private LoginViewModel viewModel;
        public LoginPage ()
		{
			InitializeComponent ();
            BindingContext = viewModel = new LoginViewModel(this);
            NavigationPage.SetHasNavigationBar(this, false);
        }

        protected override void OnAppearing()
        {
            viewModel?.Inicialize().ConfigureAwait(false);
            base.OnAppearing();
        }
    }
}