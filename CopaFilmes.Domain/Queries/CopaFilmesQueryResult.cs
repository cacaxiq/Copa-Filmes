using CopaFilmes.Domain.Entities;
using Newtonsoft.Json;
using System;

namespace CopaFilmes.Domain.Queries
{
	public class CopaFilmesQueryResult
	{
		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("titulo")]
		public string Titulo { get; set; }

		[JsonProperty("ano")]
		public long Ano { get; set; }

		[JsonProperty("nota")]
		public double Nota { get; set; }

		public Movie ConvertToMovie()
		{
			return new Movie(Id, Titulo, Ano, Nota);
		}
	}
}
