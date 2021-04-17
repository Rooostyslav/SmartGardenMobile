using SmartGardenMobile.Models.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartGardenMobile.Services.Interfaces
{
	public interface IUserService
	{
		Task<ViewUser> FindMyUserAsync();

		Task<ViewUser> FindUserByIdAsync(int userId);

		Task<IEnumerable<ViewUser>> FindAllUsers();
	}
}
