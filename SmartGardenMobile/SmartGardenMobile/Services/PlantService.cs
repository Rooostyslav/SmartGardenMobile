using SmartGardenMobile.Models.Plants;
using SmartGardenMobile.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartGardenMobile.Services
{
	public class PlantService : BaseService, IPlantService
	{
		private string baseUrl;

		public PlantService()
		{
			baseUrl = domain_api + "/api/plants/";
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
			string url = domain_api + "/api/gardens/" + gardenId + "/plants";
			return await GetQueryAsync<IEnumerable<ViewPlant>>(url);
		}

		public async Task<IEnumerable<ViewPlant>> FindMyPlantsAsync()
		{
			string url = baseUrl + "my/";
			return await GetQueryAsync<IEnumerable<ViewPlant>>(url);
		}
	}
}
