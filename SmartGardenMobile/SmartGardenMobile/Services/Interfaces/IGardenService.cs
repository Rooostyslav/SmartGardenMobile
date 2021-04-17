using SmartGardenMobile.Models.Gardens;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartGardenMobile.Services.Interfaces
{
	public interface IGardenService
	{
		Task<IEnumerable<ViewGarden>> FindMyGardensAsync();

		Task<ViewGarden> FindGardenByIdAsync(int gardenId);

		Task<IEnumerable<ViewGarden>> FindGardensByUserAsync(int userId);
	}
}
