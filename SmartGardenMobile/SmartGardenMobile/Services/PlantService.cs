using SmartGardenMobile.Models.Plants;
using SmartGardenMobile.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SmartGardenMobile.Services
{
	public class PlantService : IPlantService
	{
		private List<Plant> plants;
		private IGardenService gardenService;

		const string domain = "192.168.1.4:5000";
		private string baseUrl;

		public PlantService()
		{
			baseUrl = domain + "/api/gardens/";
			gardenService = DependencyService.Get<IGardenService>();

			plants = new List<Plant>
			{
				new Plant
				{
					Id = 1,
					Name = "plant 1",
					Description = "dexc plant 1",
					Location = "3242.2424",
					GardenId = 1
				},
				new Plant
				{
					Id = 2,
					Name = "plant 2",
					Description = "dexc plant 2",
					Location = "3442535.24236364",
					GardenId = 1
				},
				new Plant
				{
					Id = 3,
					Name = "plant 3",
					Description = "dexc plant 3",
					Location = "323434342.24243434",
					GardenId = 1
				}
			};
		}

		public async Task CreatePlantAsync(Plant plant)
		{
			await Task.Run(() => plants.Add(plant));
		}

		public async Task<Plant> FindPlantByIdAsync(int id)
		{
			var result = plants.FirstOrDefault(p => p.Id == id);
			return await Task.FromResult(result);
		}

		public async Task<IEnumerable<Plant>> FindPlantsByGardenAsync(int gardenId)
		{
			var result = plants.Where(p => p.GardenId == gardenId);
			return await Task.FromResult(result);
		}

		public async Task<IEnumerable<Plant>> FindPlantsByUserAsync(int userId)
		{
			var gardens = await gardenService.FindGardensByUserAsync(userId);
			var gardensIds = gardens.Select(g => g.Id);
			var result = plants.Where(p => gardensIds.Contains(p.GardenId));
			return await Task.FromResult(result);
		}
	}
}
