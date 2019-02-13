using CopaFilmesApp.Models;
using CopaFilmesApp.ViewModels;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CopaFilmesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MovieResult : ContentPage
    {
        private MovieResultViewModel viewModel;
        public MovieResult()
        {

        }

        public MovieResult (IEnumerable<Movie> movies)
		{
			InitializeComponent ();
            BindingContext = viewModel = new MovieResultViewModel(this, movies);
        }

        protected override void OnAppearing()
        {
            viewModel?.Inicialize().ConfigureAwait(false);
            base.OnAppearing();
        }
    }
}