using SmartGardenMobile.Models.Business;
using SmartGardenMobile.Views;
using System;
using Xamarin.Forms;

namespace SmartGardenMobile.ViewModels
{
	public class LoginViewModel : BaseViewModel
	{
		private string email = "user1@gmail.com";
		private string password = "user1";

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

		public Command LoginCommand { get; }
		public Command RegistrationCommand { get; }

		public LoginViewModel()
		{
			LoginCommand = new Command(OnLoginClicked, Validate);
			RegistrationCommand = new Command(RedirectToRegisterPage);
		}

		private bool Validate()
		{
			return !String.IsNullOrWhiteSpace(email)
				&& !String.IsNullOrWhiteSpace(password);
		}

		private async void RedirectToRegisterPage()
		{
			await Shell.Current.GoToAsync($"{nameof(RegisterPage)}");
		}

		private async void OnLoginClicked()
		{
			Login login = new Login
			{
				Email = email,
				Password = password
			};

			bool result = await AuthService.LoginAsync(login);

			if (result)
			{
				await Shell.Current.GoToAsync("..");
			}
			else
			{
				await Shell.Current.GoToAsync($"{nameof(LoginPage)}");
			}
		}
	}
}
