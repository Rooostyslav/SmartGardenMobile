
namespace SmartGardenMobile.Models.Plants
{
	public class ViewPlant : BaseModel
	{
		public string Description { get; set; }

		public string Location { get; set; }

		public int GardenId { get; set; }
	}
}
