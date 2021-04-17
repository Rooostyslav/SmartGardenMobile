
namespace SmartGardenMobile.Models.Users
{
	public class User : BaseModel
	{
		public string Email { get; set; }

		public string Password { get; set; }

		public string Role { get; set; }
	}
}
