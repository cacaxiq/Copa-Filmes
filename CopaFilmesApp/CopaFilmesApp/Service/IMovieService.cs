using System.Collections.Generic;
using System.Threading.Tasks;
using CopaFilmesApp.Models;

namespace CopaFilmesApp.Service
{
    public interface IMovieService
    {
        Task<IEnumerable<Movie>> GetMovies();
        Task<ResutMovies> GetResultChampionship(IEnumerable<Movie> movies);
    }
}