using SmartGardenMobile.Models.Gardens;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartGardenMobile.Services.Interfaces
{
	public interface IGardenService
	{
		Task<IEnumerable<Garden>> FindMyGardensAsync();

		Task<Garden> FindGardenByIdAsync(int gardenId);

		Task<IEnumerable<Garden>> FindGardensByUserAsync(int userId);

		Task CreateGardenAsync(Garden garden);
	}
}
