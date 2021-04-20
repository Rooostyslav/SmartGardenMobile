using SmartGardenMobile.Views.Gardens;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SmartGardenMobile.ViewModels
{
	public class UserCabinetViewModel : BaseViewModel
	{
		private string name;
		private string email;

		public int Id { get; set; }

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

		public Command MoveToGardensListCommand { get; }

		public UserCabinetViewModel()
		{
			Title = "User Cabinet";

			MoveToGardensListCommand = new Command(async () => await ExecuteMoveToGardensListCommand());

			LoadUser();
		}

		private async Task ExecuteMoveToGardensListCommand()
		{
			await Shell.Current.GoToAsync($"{nameof(GardensListPage)}");
		}

		private async void LoadUser()
		{
			try
			{
				var user = await UserService.FindMyUserAsync();
				Id = user.Id;
				Name = user.Name;
				Email = user.Email;
			}
			catch (Exception)
			{
				Debug.WriteLine("Failed to Load Item");
			}
		}
	}
}
