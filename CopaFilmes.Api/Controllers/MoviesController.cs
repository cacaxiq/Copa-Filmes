using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CopaFilmes.Domain.Commands;
using CopaFilmes.Domain.Handlers;
using CopaFilmes.Domain.Services;
using CopaFilmes.Infra.Commands;
using Microsoft.AspNetCore.Mvc;

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
		[HttpPost]
		public ICommandResult Post(MoviesWinsCommand command)
		{
			return movieHandler.Handle(command);
		}
	}
}