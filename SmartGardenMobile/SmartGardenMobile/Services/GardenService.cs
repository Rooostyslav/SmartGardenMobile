using SmartGardenMobile.Models.Gardens;
using SmartGardenMobile.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartGardenMobile.Services
{
	public class GardenService : BaseService, IGardenService
	{
		private readonly string baseUrl;

		public GardenService()
		{
			baseUrl = domain_api + "/api/gardens/";
		}

		public async Task<ViewGarden> FindGardenByIdAsync(int gardenId)
		{
			string url = baseUrl + gardenId + "/";
			return await GetQueryAsync<ViewGarden>(url);
		}

		public async Task<IEnumerable<ViewGarden>> FindGardensByUserAsync(int userId)
		{
			string url = domain_api + "/api/users/" + userId + "/gardens/";
			return await GetQueryAsync<IEnumerable<ViewGarden>>(url);
		}

		public async Task<IEnumerable<ViewGarden>> FindMyGardensAsync()
		{
			string url = baseUrl + "my/";
			return await GetQueryAsync<IEnumerable<ViewGarden>>(url);
		}

		public async Task CreateGardenAsync(Garden garden)
		{
			await PostQueryAsync(baseUrl, garden);
		}
	}
}
