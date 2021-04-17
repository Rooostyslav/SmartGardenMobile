using SmartGardenMobile.Models.Gardens;
using System;
using Xamarin.Forms;

namespace SmartGardenMobile.ViewModels.Gardens
{
	public class NewGardenViewModel : BaseViewModel
	{
		private string name;
		private string description;

		public NewGardenViewModel()
		{
			SaveCommand = new Command(OnSave, ValidateSave);
			CancelCommand = new Command(OnCancel);

			this.PropertyChanged +=
				(_, __) => SaveCommand.ChangeCanExecute();
		}

		private bool ValidateSave()
		{
			return !String.IsNullOrWhiteSpace(name)
				&& !String.IsNullOrWhiteSpace(description);
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

		public Command SaveCommand { get; }
		public Command CancelCommand { get; }

		private async void OnCancel()
		{
			await Shell.Current.GoToAsync("..");
		}

		private async void OnSave()
		{
			Garden newGarden = new Garden()
			{
				Id = 5,
				Name = Name,
				Description = Description,
				UserId = 2
			};

			await GardenService.CreateGardenAsync(newGarden);

			// This will pop the current page off the navigation stack
			await Shell.Current.GoToAsync("..");
		}
	}
}
