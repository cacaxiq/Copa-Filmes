﻿using CopaFilmesApp.Models;
using CopaFilmesApp.Service;
using CopaFilmesApp.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CopaFilmesApp.ViewModels
{
    public class MovieListViewModel : BaseViewModel
    {
        public MovieListViewModel(Page page) : base(page)
        {
            Movies = new ObservableCollection<Models.Movie>();
            service = DependencyService.Get<IMovieService>();
            if (service == null)
            {
                throw new System.ArgumentNullException(nameof(service));
            }

            GenerateChampionshipCommand = new Command(async () => await GenerateChampionship());
            RefreshCommand = new Command(async () => await Refresh());
            RemoveMovieCommand = new Command<Movie>(RemoveMovie);
        }

        private void RemoveMovie(Movie movie)
        {
            if (Movies.Count == 8)
            {
                page.DisplayAlert("Aviso", "Limite de filmes removidos atingido.", "Ok");
                return;
            }
            
            Movies.Remove(movie);

            SelectedMovies = $"Selecionados {Movies.Count} de 8 filmes";

            page.DisplayAlert("Sucesso", "Filmes removido.", "Ok");
        }
        private async Task GenerateChampionship()
        {
			if (Movies.Count > 8)
			{
				await page.DisplayAlert("Aviso", "Limite de filmes removidos ainda não atingido.", "Ok");
				return;
			}

			var result = await page.DisplayAlert("Iniciar Campeonato", "Voce já pode comecar o campeonato.", "Sim", "Nao");

            if (result)
            {
                await page.Navigation.PushAsync(new MovieResult(Movies));
            }
        }
        private async Task Refresh()
        {
            IsRefresh = true;
            Movies.Clear();
            var list = await service.GetMovies();


            if (list != null)
            {
                foreach (var item in list.ToList())
                {
                    Movies.Add(item);
                }
                SelectedMovies = $"Selecionados {Movies.Count} de 8 filmes";
            }
            else
            {
                IsRefresh = false;
                await page.DisplayAlert("Erro", "Nenhum filme encontrado.", "Ok");
            }

            IsRefresh = false;
        }

        public ObservableCollection<Models.Movie> Movies { get; set; }
        private readonly IMovieService service;

        private string selectedMovies;
        public string SelectedMovies
        {
            get { return selectedMovies; }
            set
            {
                selectedMovies = value;
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

        public ICommand GenerateChampionshipCommand { get; set; }
        public ICommand RemoveMovieCommand { get; set; }
        public ICommand RefreshCommand { get; set; }

        public override async Task Inicialize()
        {
            await Refresh();
        }
    }
}
