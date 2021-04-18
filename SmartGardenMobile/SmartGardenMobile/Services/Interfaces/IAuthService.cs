using SmartGardenMobile.Models.Business;
using System.Threading.Tasks;

namespace SmartGardenMobile.Services.Interfaces
{
	public interface IAuthService
	{
		Task<bool> LoginAsync(Login login);

		Task<bool> IsLogged();

		Task<bool> Logout();
	}
}
