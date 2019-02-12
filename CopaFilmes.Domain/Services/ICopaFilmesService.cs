using System.Threading;
using System.Threading.Tasks;
using CopaFilmes.Infra.Commands;

namespace CopaFilmes.Domain.Services
{
	public interface ICopaFilmesService
	{
		Task<ICommandResult> GetCopaFilmes();
	}
}