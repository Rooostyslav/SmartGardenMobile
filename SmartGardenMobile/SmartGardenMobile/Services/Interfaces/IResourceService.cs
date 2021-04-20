using SmartGardenMobile.Models.Resources;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartGardenMobile.Services.Interfaces
{
	public interface IResourceService
	{
		Task<IEnumerable<ViewResource>> FindMyResourcesAsync();

		Task<ViewResource> FindResourceByIdAsync(int resourceId);

		Task CreateResourceAsync(Resource resource);
	}
}
