using SmartGardenMobile.Models.Plants;
using System;
using Xamarin.Forms;

namespace SmartGardenMobile.ViewModels.Plants
{
	public class NewPlantViewModel : BaseViewModel
	{
		private string name;
		private string description;
		private string location;

		public NewPlantViewModel()
		{
			SaveCommand = new Command(OnSave, ValidateSave);
			CancelCommand = new Command(OnCancel);

			this.PropertyChanged +=
				(_, __) => SaveCommand.ChangeCanExecute();
		}

		private bool ValidateSave()
		{
			return !String.IsNullOrWhiteSpace(name)
				&& !String.IsNullOrWhiteSpace(description)
				&& !String.IsNullOrWhiteSpace(location);
		}

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

		public Command SaveCommand { get; }
		public Command CancelCommand { get; }

		private async void OnCancel()
		{
			await Shell.Current.GoToAsync("..");
		}

		private async void OnSave()
		{
			Plant newPlant = new Plant()
			{
				Name = Name,
				Description = Description,
				Location = Location,
				GardenId = 0
			};

			await PlantService.CreatePlantAsync(newPlant);

			// This will pop the current page off the navigation stack
			await Shell.Current.GoToAsync("..");
		}
	}
}
