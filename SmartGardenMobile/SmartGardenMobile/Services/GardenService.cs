using SmartGardenMobile.Models.Gardens;
using SmartGardenMobile.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartGardenMobile.Services
{
	public class GardenService : BaseService, IGardenService
	{
		private List<Garden> gardens;

		const string domain = "192.168.1.4:5000";
		private string baseUrl;

		public GardenService()
		{
			baseUrl = domain + "/api/gardens/";
			gardens = new List<Garden>
			{
				new Garden
				{
					Id = 1,
					Name = "garden 1",
					Description = "desc garden 1",
					UserId = 2
				},
				new Garden
				{
					Id = 2,
					Name = "garden 2",
					Description = "desc garden 2",
					UserId = 2
				},
				new Garden
				{
					Id = 3,
					Name = "garden 3",
					Description = "desc garden 3",
					UserId = 2
				},
			};
		}

		public async Task<Garden> FindGardenByIdAsync(int gardenId)
		{
			var result = gardens.First(g => g.Id == gardenId);//.Where();
			return await Task.FromResult(result);

			//return await GetQueryAsync<ViewGarden>(baseUrl + gardenId + "/");
		}

		public async Task<IEnumerable<Garden>> FindGardensByUserAsync(int userId)
		{
			var result = gardens.Where(g => g.UserId == userId);//.Where();
			return await Task.FromResult(result);

			//string url = domain + "/api/users/" + userId + "/gardens/";
			//return await GetQueryAsync<IEnumerable<ViewGarden>>(url);
		}

		public async Task<IEnumerable<Garden>> FindMyGardensAsync()
		{
			var result = gardens; //.Where(g => g.UserId == userId);//.Where();
			return await Task.FromResult(result);

			//return await GetQueryAsync<IEnumerable<ViewGarden>>(baseUrl + "my/");
		}

		public async Task CreateGardenAsync(Garden garden)
		{
			await Task.Run(() => gardens.Add(garden));
		}
	}
}
