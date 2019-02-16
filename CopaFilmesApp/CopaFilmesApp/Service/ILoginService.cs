using System.Threading.Tasks;

namespace CopaFilmesApp.Service
{
    public interface ILoginService
    {
        Task<string> GetLogin(string usuario, string senha);
    }
}