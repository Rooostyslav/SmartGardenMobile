using SmartGardenMobile.Models.Actions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartGardenMobile.Services.Interfaces
{
	public interface IActionService
	{
		Task<IEnumerable<ViewAction>> FindMyActionsAsync();

		Task<ViewAction> FindActionByIdAsync(int actionId);

		Task CreateActionAsync(Action action);
	}
}
