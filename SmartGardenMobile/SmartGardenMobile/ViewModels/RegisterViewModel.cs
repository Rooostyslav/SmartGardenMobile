using SmartGardenMobile.Models.Users;
using SmartGardenMobile.Views;
using System;
using Xamarin.Forms;

namespace SmartGardenMobile.ViewModels
{
	public class RegisterViewModel : BaseViewModel
	{
		private string name;
		private string email;
		private string password;

		public RegisterViewModel()
		{
			SaveCommand = new Command(OnSave, ValidateSave);
			CancelCommand = new Command(OnCancel);

			this.PropertyChanged +=
				(_, __) => SaveCommand.ChangeCanExecute();
		}

		private bool ValidateSave()
		{
			return !String.IsNullOrWhiteSpace(name) 
				&& !String.IsNullOrWhiteSpace(email) 
				&& !String.IsNullOrWhiteSpace(password);
		}

		public string Name
		{
			get => name;
			set => SetProperty(ref name, value);
		}

		public string Email
		{
			get => email;
			set => SetProperty(ref email, value);
		}
		public string Password
		{
			get => password;
			set => SetProperty(ref password, value);
		}

		public Command SaveCommand { get; }
		public Command CancelCommand { get; }

		private async void OnCancel()
		{
			await Shell.Current.GoToAsync("..");
		}

		private async void OnSave()
		{
			User newUser = new User()
			{
				Name = Name,
				Email = Email,
				Password = Password
			};

			bool result = await UserService.CreateUserAsync(newUser);

			if (result)
			{
				await Shell.Current.GoToAsync("..");
			}
			else
			{
				await Shell.Current.GoToAsync($"{nameof(RegisterPage)}");
			}
		}
	}
}
