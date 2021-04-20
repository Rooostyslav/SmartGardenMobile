using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace SmartGardenMobile.ViewModels.Resources
{
	[QueryProperty(nameof(ResourceId), nameof(ResourceId))]
	public class ResourceDetailViewModel : BaseViewModel
	{
		private int resourceId;
		private string name;
		private int amount;

		public int Id { get; set; }

		public string Name
		{
			get => name;
			set => SetProperty(ref name, value);
		}

		public int Amount
		{
			get => amount;
			set => SetProperty(ref amount, value);
		}

		public int ResourceId
		{
			get
			{
				return resourceId;
			}
			set
			{
				resourceId = value;
				LoadResourceId(value);
			}
		}

		public async void LoadResourceId(int resourceId)
		{
			try
			{
				var resource = await ResourceService.FindResourceByIdAsync(resourceId);
				Id = resource.Id;
				Name = resource.Name;
				Amount = resource.Amount;
			}
			catch (Exception)
			{
				Debug.WriteLine("Failed to Load Item");
			}
		}
	}
}
