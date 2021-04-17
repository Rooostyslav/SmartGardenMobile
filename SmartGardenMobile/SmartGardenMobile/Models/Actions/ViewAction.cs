using System;

namespace SmartGardenMobile.Models.Actions
{
	public class ViewAction : BaseModel
	{
		public DateTime Date { get; set; }

		public bool Status { get; set; }

		public int PlantId { get; set; }
	}
}
