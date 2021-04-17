using System;
using System.Diagnostics;

using Xamarin.Forms;

namespace SmartGardenMobile.ViewModels.Plants
{
	[QueryProperty(nameof(PlantId), nameof(PlantId))]
	public class PlantDetailViewModel : BaseViewModel
	{
		private int plantId;
		private string name;
		private string description;
		private string location;

		public int Id { get; set; }

		public string Name
		{
			get => name;
			set => SetProperty(ref name, value);
		}

		public string Description
		{
			get => description;
			set => SetProperty(ref description, value);
		}

		public string Location
		{
			get => location;
			set => SetProperty(ref location, value);
		}

		public int PlantId
		{
			get
			{
				return plantId;
			}
			set
			{
				plantId = value;
				LoadPlantId(value);
			}
		}

		public async void LoadPlantId(int plantId)
		{
			try
			{
				var plant = await PlantService.FindPlantByIdAsync(plantId);
				Id = plant.Id;
				Name = plant.Name;
				Description = plant.Description;
				Location = plant.Location;
			}
			catch (Exception)
			{
				Debug.WriteLine("Failed to Load Item");
			}
		}
	}
}
