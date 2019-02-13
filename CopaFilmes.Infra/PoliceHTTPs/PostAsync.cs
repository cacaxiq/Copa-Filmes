using CopaFilmes.Infra.Helpers;
using Polly;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CopaFilmes.Infra.PoliceHTTPs
{
    public static class PostAsync
    {
        public static async Task<Result<string>> ExecuteAsync(string url, string data)
        {
            var response = new Result<string> { Success = false, Message = $"Falha requisição na api: {url}" };

            var client = new HttpClient();

            var policy = Policy.Handle<Exception>().RetryAsync(3, (exception, attempt) =>
            {
                ConsoleHelper.WriteLineInColor("Policy logging: " + exception.Message, ConsoleColor.Yellow);
            });

            try
            {
                await policy.ExecuteAsync(async () =>
                {

                    var result = await client.PostAsync(url, new StringContent(data));

                    result.EnsureSuccessStatusCode();
                    string content = await result.Content.ReadAsStringAsync();

                    response = new Result<string> { Success = true, Content = content };

                    ConsoleHelper.WriteLineInColor("Response : " + response.Content, ConsoleColor.Green);
                });
            }
            catch (Exception e)
            {
                response = new Result<string> { Success = false, Message = e.Message };

                ConsoleHelper.WriteLineInColor("Request falha eventual por: " + e.Message, ConsoleColor.Red);
            }

            return response;
        }
    }
}
