using CopaFilmes.Domain.Commands;
using CopaFilmes.Domain.Handlers;
using CopaFilmes.Domain.Services;
using CopaFilmes.Infra.Commands;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CopaFilmes.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MoviesController : Controller
    {
		private readonly ICopaFilmesService service;
		private readonly MovieHandler movieHandler;

		public MoviesController(ICopaFilmesService service, MovieHandler movieHandler)
		{
			this.service = service;
			this.movieHandler = movieHandler;
		}

		// GET api/values
		[HttpGet]
		public async Task<ICommandResult> Get()
		{
			return await service.GetCopaFilmes();
		}
		
		// GET api/values
		[HttpGet]
		public ICommandResult GetResultChampionship(MoviesWinsCommand command)
		{
			return movieHandler.Handle(command);
		}
	}
}