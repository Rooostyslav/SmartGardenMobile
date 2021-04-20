using System;
using Xamarin.Forms;
using Action = SmartGardenMobile.Models.Actions.Action;

namespace SmartGardenMobile.ViewModels.Actions
{
	public class NewActionViewModel : BaseViewModel
	{
		private string name;

		public NewActionViewModel()
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

		public Command SaveCommand { get; }
		public Command CancelCommand { get; }

		private async void OnCancel()
		{
			await Shell.Current.GoToAsync("..");
		}

		private async void OnSave()
		{
			Action newAction = new Action()
			{
				Name = Name,
				Status = false,
				Date = DateTime.Now,
				PlantId = 0
			};

			await ActionService.CreateActionAsync(newAction);

			await Shell.Current.GoToAsync("..");
		}
	}
}
