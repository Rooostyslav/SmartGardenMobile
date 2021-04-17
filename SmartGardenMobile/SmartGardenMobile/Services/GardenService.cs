using SmartGardenMobile.Models.Gardens;
using SmartGardenMobile.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartGardenMobile.Services
{
	public class GardenService : BaseService, IGardenService
	{
		const string domain = "http://localhost:5000";
		private string baseUrl;

		public GardenService()
		{
			baseUrl = domain + "/api/gardens/";
		}

		public async Task<ViewGarden> FindGardenByIdAsync(int gardenId)
		{
			return await GetQueryAsync<ViewGarden>(baseUrl + gardenId);
		}

		public async Task<IEnumerable<ViewGarden>> FindGardensByUserAsync(int userId)
		{
			string url = domain + "/users/" + userId + "/gardens";
			return await GetQueryAsync<IEnumerable<ViewGarden>>(url);
		}

		public async Task<IEnumerable<ViewGarden>> FindMyGardensAsync()
		{
			return await GetQueryAsync<IEnumerable<ViewGarden>>(baseUrl + "my");
		}
	}
}
