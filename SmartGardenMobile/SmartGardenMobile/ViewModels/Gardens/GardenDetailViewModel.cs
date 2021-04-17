using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace SmartGardenMobile.ViewModels.Gardens
{
	[QueryProperty(nameof(GardenId), nameof(GardenId))]
	public class GardenDetailViewModel : BaseViewModel
	{
		private int gardenId;
		private string name;
		private string description;

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

		public int GardenId
		{
			get
			{
				return gardenId;
			}
			set
			{
				gardenId = value;
				LoadGardenId(value);
			}
		}

		public async void LoadGardenId(int gardenId)
		{
			try
			{
				var garden = await GardenService.FindGardenByIdAsync(gardenId);
				Id = garden.Id;
				Name = garden.Name;
				Description = garden.Description;
			}
			catch (Exception)
			{
				Debug.WriteLine("Failed to Load Item");
			}
		}
	}
}
