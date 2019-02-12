using CopaFilmes.Domain.Entities;
using CopaFilmes.Domain.ValueObjects;

namespace CopaFilmes.Domain.Services
{
	public interface IMoviesChampionshipService
	{
		ResutMovies GetResultChampionship(Movie[] movies);
	}
}