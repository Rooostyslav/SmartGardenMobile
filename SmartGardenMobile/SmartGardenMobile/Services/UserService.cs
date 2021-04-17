using SmartGardenMobile.Models.Users;
using SmartGardenMobile.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartGardenMobile.Services
{
	public class UserService : BaseService, IUserService
	{
		private const string domain = "http://localhost:5000";
		private string baseUrl;

		private List<User> users;

		public UserService()
		{
			baseUrl = domain + "/api/users/";
			users = new List<User>
			{
				new User
				{
					Id = 1,
					Name = "admin",
					Email = "admin@gmail.com",
					Password = "admin",
					Role = "admin"
				},
				new User
				{
					Id = 2,
					Name = "user",
					Email = "user@gmail.com",
					Password = "user",
					Role = "user"
				}
			};
		}
		
		public async Task<IEnumerable<User>> FindAllUsers()
		{
			return await Task.FromResult(users);

			//return await GetQueryAsync<IEnumerable<ViewUser>>(baseUrl);
		}

		public async Task<User> FindMyUserAsync()
		{
			var result = users.First();//.Where();
			return await Task.FromResult(result);

			//return await GetQueryAsync<ViewUser>(baseUrl + "my");
		}

		public async Task<User> FindUserByIdAsync(int userId)
		{
			var result = users.First(u => u.Id == userId);//.Where();
			return await Task.FromResult(result);

			//return await GetQueryAsync<ViewUser>(baseUrl + userId);
		}

		public async Task<User> LoginAsync(string email, string password)
		{
			var result = users
				.FirstOrDefault(u => u.Email == email && u.Password == password);
			return await Task.FromResult(result);
		}
	}
}
