using SmartGardenMobile.Models.Plants;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartGardenMobile.Services.Interfaces
{
	public interface IPlantService
	{
		Task<IEnumerable<Plant>> FindPlantsByGardenAsync(int gardenId);

		Task<Plant> FindPlantByIdAsync(int id);

		Task<IEnumerable<Plant>> FindPlantsByUserAsync(int userId);

		Task CreatePlantAsync(Plant plant);
	}
}
