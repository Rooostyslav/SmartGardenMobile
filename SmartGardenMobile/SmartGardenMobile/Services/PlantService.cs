using SmartGardenMobile.Models.Plants;
using SmartGardenMobile.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartGardenMobile.Services
{
	public class PlantService : BaseService, IPlantService
	{
		const string domain = "http://192.168.1.4:5000";
		private string baseUrl;

		public PlantService()
		{
			baseUrl = domain + "/api/plants/";
		}

		public async Task CreatePlantAsync(Plant plant)
		{
			await PostQueryAsync(baseUrl, plant);
		}

		public async Task<ViewPlant> FindPlantByIdAsync(int id)
		{
			string url = baseUrl + id + "/";
			return await GetQueryAsync<ViewPlant>(url);
		}

		public async Task<IEnumerable<ViewPlant>> FindPlantsByGardenAsync(int gardenId)
		{
			string url = domain + "/api/gardens/" + gardenId + "/plants";
			return await GetQueryAsync<IEnumerable<ViewPlant>>(url);
		}

		public async Task<IEnumerable<ViewPlant>> FindMyPlantsAsync()
		{
			string url = baseUrl + "my/";
			return await GetQueryAsync<IEnumerable<ViewPlant>>(url);
		}
	}
}
