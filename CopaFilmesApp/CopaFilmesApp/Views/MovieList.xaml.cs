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
        }

        protected override void OnAppearing()
        {
            viewModel?.Inicialize().ConfigureAwait(false);
            base.OnAppearing();
        }
    }
}
