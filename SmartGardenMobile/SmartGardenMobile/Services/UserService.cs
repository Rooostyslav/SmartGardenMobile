using SmartGardenMobile.Models.Users;
using SmartGardenMobile.Services.Interfaces;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace SmartGardenMobile.Services
{
	public class UserService : BaseService, IUserService
	{
		private string baseUrl;

		public UserService()
		{
			baseUrl = domain_api + "/api/users/";
		}

		public async Task<bool> CreateUserAsync(User user)
		{
			var response = await PostQueryWithResponseAsync(baseUrl, user);

			if (response.StatusCode == HttpStatusCode.OK)
			{
				return true;
			}

			return false;
		}

		public async Task<IEnumerable<ViewUser>> FindAllUsers()
		{
			return await GetQueryAsync<IEnumerable<ViewUser>>(baseUrl);
		}

		public async Task<ViewUser> FindMyUserAsync()
		{
			return await GetQueryAsync<ViewUser>(baseUrl + "my/");
		}

		public async Task<ViewUser> FindUserByIdAsync(int userId)
		{
			return await GetQueryAsync<ViewUser>(baseUrl + $"{userId}/");
		}
	}
}
