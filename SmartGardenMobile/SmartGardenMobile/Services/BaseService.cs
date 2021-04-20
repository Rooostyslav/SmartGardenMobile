using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace SmartGardenMobile.Services
{
	public abstract class BaseService
	{
		protected const string domain_api = "http://192.168.1.4:5000";

		protected const string domain_auth_api = "http://192.168.1.4:5001";

		protected const string nameAccessToken = "access_token";

		private JsonSerializerOptions options = new JsonSerializerOptions
		{
			PropertyNameCaseInsensitive = true,
		};

		private HttpClient GetClient()
		{
			HttpClient client = new HttpClient();
			client.DefaultRequestHeaders.Add("Accept", "application/json");

			if (IsAuthorized())
			{
				string token = GetToken();
				client.DefaultRequestHeaders.Authorization =
					new AuthenticationHeaderValue("Bearer", token);
			}

			return client;
		}

		protected bool IsAuthorized()
		{
			return App.Current.Properties.ContainsKey(nameAccessToken);
		}

		private string GetToken()
		{
			return App.Current.Properties[nameAccessToken].ToString();
		}

		protected async Task<TResult> GetQueryAsync<TResult>(string url)
		{
			string result = await GetClient().GetStringAsync(url);
			return JsonSerializer.Deserialize<TResult>(result, options);
		}

		protected async Task<HttpResponseMessage> PostQueryWithResponseAsync<T>(string url, T obj)
		{
			var stringContext =
				new StringContent(
					JsonSerializer.Serialize(obj),
					Encoding.UTF8, "application/json");

			return await GetClient().PostAsync(url, stringContext);
		}

		protected async Task<bool> PostQueryAsync<T>(string url, T obj)
		{
			var response = await PostQueryWithResponseAsync(url, obj);

			if (response.StatusCode == HttpStatusCode.OK)
			{
				return true;
			}

			return false;
		}
	}
}
