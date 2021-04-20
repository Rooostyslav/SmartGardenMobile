using SmartGardenMobile.Models.Resources;
using System;
using Xamarin.Forms;

namespace SmartGardenMobile.ViewModels.Resources
{
	public class NewResourceViewModel : BaseViewModel
	{
		private string name;
		private int amount;

		public NewResourceViewModel()
		{
			SaveCommand = new Command(OnSave, ValidateSave);
			CancelCommand = new Command(OnCancel);

			this.PropertyChanged +=
				(_, __) => SaveCommand.ChangeCanExecute();
		}

		private bool ValidateSave()
		{
			return !String.IsNullOrWhiteSpace(name);
		}

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

		public Command SaveCommand { get; }
		public Command CancelCommand { get; }

		private async void OnCancel()
		{
			await Shell.Current.GoToAsync("..");
		}

		private async void OnSave()
		{
			Resource newResource = new Resource()
			{
				Name = Name,
				Amount = Amount,
				GardenId = 0
			};

			await ResourceService.CreateResourceAsync(newResource);

			await Shell.Current.GoToAsync("..");
		}
	}
}
