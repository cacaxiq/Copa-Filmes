using CopaFilmes.Infra.PoliceHTTPs;
using CopaFilmesApp.Service;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(LoginService))]
namespace CopaFilmesApp.Service
{
    public class LoginService : ILoginService
    {
        public async Task<string> GetLogin(string usuario, string senha)
        {
            if (usuario == null)
            {
                throw new System.ArgumentNullException(nameof(usuario));
            }

            if (senha == null)
            {
                throw new System.ArgumentNullException(nameof(senha));
            }

            var data = $"{{  \"userID\": \"{usuario}\",  \"accessKey\": \"{senha}\"}}";
            var loginResult = await PostAsync.ExecuteAsync("http://copafilmes.azurewebsites.net/api/Login", data);

            if (loginResult.Success)
            {
                JToken root = JObject.Parse(loginResult.Content);
                var authenticated = bool.Parse(root["authenticated"].ToString());

                if (authenticated)
                    return root["token"].ToString();
            }

            return null;
        }
    }
}
