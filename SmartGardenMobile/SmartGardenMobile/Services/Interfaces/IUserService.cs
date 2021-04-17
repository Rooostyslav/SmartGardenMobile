using SmartGardenMobile.Models.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartGardenMobile.Services.Interfaces
{
	public interface IUserService
	{
		Task<User> LoginAsync(string email, string password);

		Task<User> FindMyUserAsync();

		Task<User> FindUserByIdAsync(int userId);

		Task<IEnumerable<User>> FindAllUsers();
	}
}
