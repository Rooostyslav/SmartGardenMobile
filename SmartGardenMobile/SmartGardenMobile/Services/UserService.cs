using SmartGardenMobile.Models.Users;
using SmartGardenMobile.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartGardenMobile.Services
{
	public class UserService : BaseService, IUserService
	{
		private const string domain = "http://localhost:5000";
		private string baseUrl;

		public UserService()
		{
			baseUrl = domain + "/api/users/";
		}
		
		public async Task<IEnumerable<ViewUser>> FindAllUsers()
		{
			return await GetQueryAsync<IEnumerable<ViewUser>>(baseUrl);
		}

		public async Task<ViewUser> FindMyUserAsync()
		{
			return await GetQueryAsync<ViewUser>(baseUrl + "my");
		}

		public async Task<ViewUser> FindUserByIdAsync(int userId)
		{
			return await GetQueryAsync<ViewUser>(baseUrl + userId);
		}
	}
}
