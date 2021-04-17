using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace SmartGardenMobile.Services
{
	public abstract class BaseService
	{
		private JsonSerializerOptions options = new JsonSerializerOptions
		{
			PropertyNameCaseInsensitive = true,
		};

		private HttpClient GetClient()
		{
			HttpClient client = new HttpClient();
			client.DefaultRequestHeaders.Add("Accept", "application/json");
			return client;
		}

		protected async Task<TResult> GetQueryAsync<TResult>(string url)
		{
			string result = await GetClient().GetStringAsync(url);
			return JsonSerializer.Deserialize<TResult>(result, options);
		}
	}
}
