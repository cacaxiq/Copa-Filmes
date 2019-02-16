using CopaFilmes.Infra.Helpers;
using Polly;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CopaFilmes.Infra.PoliceHTTPs
{
    public static class GetAsync
    {
        public static async Task<Result<string>> ExecuteAsync(string url)
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
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "Your Oauth token");

                    var result = await client.GetStringAsync(url);

                    response = new Result<string> { Success = true, Content = result };

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

        public static async Task<Result<string>> ExecuteAsync(string url, string token)
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
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    var result = await client.GetStringAsync(url);

                    response = new Result<string> { Success = true, Content = result };

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
