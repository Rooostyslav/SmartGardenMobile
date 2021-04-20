using SmartGardenMobile.Models.Resources;
using SmartGardenMobile.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartGardenMobile.Services
{
	public class ResourceService : BaseService, IResourceService
	{
		private string baseUrl;

		public ResourceService()
		{
			baseUrl = domain_api + "/api/resources/";
		}

		public async Task CreateResourceAsync(Resource resource)
		{
			await PostQueryAsync(baseUrl, resource);
		}

		public async Task<IEnumerable<ViewResource>> FindMyResourcesAsync()
		{
			string url = baseUrl + "my/";
			return await GetQueryAsync<IEnumerable<ViewResource>>(url);
		}

		public async Task<ViewResource> FindResourceByIdAsync(int resourceId)
		{
			string url = baseUrl + resourceId + "/";
			return await GetQueryAsync<ViewResource>(url);
		}
	}
}
