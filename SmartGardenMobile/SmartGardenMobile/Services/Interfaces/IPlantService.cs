using SmartGardenMobile.Models.Plants;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartGardenMobile.Services.Interfaces
{
	public interface IPlantService
	{
		Task<IEnumerable<ViewPlant>> FindMyPlantsAsync();

		Task<IEnumerable<ViewPlant>> FindPlantsByGardenAsync(int gardenId);

		Task<ViewPlant> FindPlantByIdAsync(int id);

		Task CreatePlantAsync(Plant plant);
	}
}
