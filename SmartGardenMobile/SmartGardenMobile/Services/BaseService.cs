using System.Net;
using System.Net.Http;
using System.Text;
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

		protected async Task<bool> PostQueryAsync<T>(string url, T obj)
		{
			var stringContext = 
				new StringContent(
					JsonSerializer.Serialize(obj), 
					Encoding.UTF8, "application/json");

			var response = await GetClient().PostAsync(url, stringContext);
			
			if (response.StatusCode == HttpStatusCode.OK)
			{
				return true;
			}

			return false;
		}
	}
}
