using CopaFilmesApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CopaFilmesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MovieList : ContentPage
    {
        private MovieListViewModel viewModel;

        public MovieList()
        {
            InitializeComponent();
            BindingContext = viewModel = new MovieListViewModel(this);
            NavigationPage.SetHasBackButton(this, false);
        }

        protected override void OnAppearing()
        {
            viewModel?.Inicialize().ConfigureAwait(false);
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            viewModel?.Destroy().ConfigureAwait(false);
            base.OnDisappearing();
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}
