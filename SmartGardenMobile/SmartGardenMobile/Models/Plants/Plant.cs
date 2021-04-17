
namespace SmartGardenMobile.Models.Plants
{
	public class Plant : BaseModel
	{
		public string Description { get; set; }

		public string Location { get; set; }

		public int GardenId { get; set; }
	}
}
