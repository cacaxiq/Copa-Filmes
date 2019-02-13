
using CopaFilmesApp.Models;
using CopaFilmesApp.Service;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CopaFilmesApp.ViewModels
{
    public class MovieResultViewModel: BaseViewModel
    {
        public MovieResultViewModel(Page page, IEnumerable<Movie> movies) : base(page)
        {
            Movies = movies ?? throw new System.ArgumentNullException(nameof(movies));

            service = DependencyService.Get<IMovieService>();
            if (service == null)
            {
                throw new System.ArgumentNullException(nameof(service));
            }
        }

        private readonly IMovieService service;

        private Movie champion;
        public Movie Champion
        {
            get { return champion; }
            set
            {
                champion = value;
                NotifyPropertyChanged();
            }
        }

        private Movie secondPlace;
        public Movie SecondPlace
        {
            get { return secondPlace; }
            set
            {
                secondPlace = value;
                NotifyPropertyChanged();
            }
        }

        private bool isRefresh;
        public bool IsRefresh
        {
            get { return isRefresh; }
            set
            {
                isRefresh = value;
                NotifyPropertyChanged();
            }
        }

        public IEnumerable<Movie> Movies { get; }

        public override async Task Inicialize()
        {
            IsRefresh = true;
            var result = await service.GetResultChampionship(Movies);

            if (result !=  null)
            {
                Champion = result.Champion;
                SecondPlace = result.SecondPlace;
            }
            else
            {
                IsRefresh = false;
                await page.DisplayAlert("Erro", "Nao foi possivel obter o resultado do campeonato.", "Ok");
            }

            IsRefresh = false;
        }
    }
}
