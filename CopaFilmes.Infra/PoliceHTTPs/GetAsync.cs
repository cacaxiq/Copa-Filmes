using CopaFilmes.Infra.Helpers;
using Polly;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CopaFilmes.Infra.PoliceHTTPs
{
	public static class GetAsync
	{
		public static async Task<Result<string>> ExecuteAsync(string url, CancellationToken cancellationToken)
		{
			var response = new Result<string> { Success = false, Message = $"Falha requisição na api: {url}" };
			Console.WriteLine(typeof(GetAsync).Name);
			Console.WriteLine("=======");

			var client = new HttpClient();
			int eventualSuccesses = 0;
			int retries = 0;
			int eventualFailures = 0;

			var policy = Policy.Handle<Exception>().RetryAsync(3, (exception, attempt) =>
			{
				ConsoleHelper.WriteLineInColor("Policy logging: " + exception.Message, ConsoleColor.Yellow);
				retries++;
			});

			int i = 0;
			while (!cancellationToken.IsCancellationRequested)
			{
				i++;

				try
				{
					await policy.ExecuteAsync(async () =>
					{
						var result = await client.GetStringAsync(url);

						response = new Result<string> { Success = true, Content = result };

						ConsoleHelper.WriteLineInColor("Response : " + response, ConsoleColor.Green);
						eventualSuccesses++;
					});
				}
				catch (Exception e)
				{
					response = new Result<string> { Success = false, Message = e.Message };

					ConsoleHelper.WriteLineInColor("Request " + i + " falha eventual por: " + e.Message, ConsoleColor.Red);
					eventualFailures++;
				}

				await Task.Delay(TimeSpan.FromSeconds(0.5), cancellationToken);
			}

			Console.WriteLine("");
			Console.WriteLine("Total de request feitas: " + i);
			Console.WriteLine("Requests que eventualmente foram bem-sucedidas: " + eventualSuccesses);
			Console.WriteLine("Tentativas feitas para ajudar a alcançar o sucesso: " + retries);
			Console.WriteLine("Requests que eventualmente falharam: " + eventualFailures);

			return response;
		}
	}
}
