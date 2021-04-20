using SmartGardenMobile.Models.Actions;
using SmartGardenMobile.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartGardenMobile.Services
{
	public class ActionService : BaseService, IActionService
	{
		private string baseUrl;

		public ActionService()
		{
			baseUrl = domain_api + "/api/actions/";
		}

		public async Task CreateActionAsync(Action action)
		{
			await PostQueryAsync(baseUrl, action);
		}

		public async Task<ViewAction> FindActionByIdAsync(int actionId)
		{
			string url = baseUrl + actionId + "/";
			return await GetQueryAsync<ViewAction>(url);
		}

		public async Task<IEnumerable<ViewAction>> FindMyActionsAsync()
		{
			string url = baseUrl + "my/";
			return await GetQueryAsync<IEnumerable<ViewAction>>(url);
		}
	}
}
