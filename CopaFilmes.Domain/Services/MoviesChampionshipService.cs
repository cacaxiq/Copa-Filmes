using CopaFilmes.Domain.Entities;
using CopaFilmes.Domain.ValueObjects;
using System.Collections.Generic;

namespace CopaFilmes.Domain.Services
{
	public class MoviesChampionshipService : IMoviesChampionshipService
	{
		public ResutMovies GetResultChampionship(Movie[] movies)
		{
			var phase1 = MovieDispute(movies[0], movies[7]);
			var phase2 = MovieDispute(movies[1], movies[6]);
			var phase3 = MovieDispute(movies[2], movies[5]);
			var phase4 = MovieDispute(movies[3], movies[4]);

			var phase5 = MovieDispute(phase1.Champion, phase2.Champion);
			var phase6 = MovieDispute(phase3.Champion, phase4.Champion);

			return MovieDispute(phase5.Champion, phase6.Champion);
		}

		private ResutMovies MovieDispute(Movie movieA, Movie movieB)
		{
			if (movieA.Nota == movieB.Nota)
				return string.Compare(movieA.Titulo, movieB.Titulo) < 0 ? new ResutMovies { Champion = movieA, SecondPlace = movieB } : new ResutMovies { Champion = movieB, SecondPlace = movieA };

			return movieA.Nota > movieB.Nota ? new ResutMovies { Champion = movieA, SecondPlace = movieB } : new ResutMovies { Champion = movieB, SecondPlace = movieA };
		}
	}
}
