using SmartGardenMobile.Services.Interfaces;
using SmartGardenMobile.Views;
using SmartGardenMobile.Views.Actions;
using SmartGardenMobile.Views.Gardens;
using SmartGardenMobile.Views.Plants;
using SmartGardenMobile.Views.Resources;
using System;
using Xamarin.Forms;

namespace SmartGardenMobile
{
	public partial class AppShell : Shell
	{
		public AppShell()
		{
			InitializeComponent();

			Routing.RegisterRoute(nameof(GardensListPage), typeof(GardensListPage));
			Routing.RegisterRoute(nameof(GardenDetailPage), typeof(GardenDetailPage));
			Routing.RegisterRoute(nameof(NewGardenPage), typeof(NewGardenPage));

			Routing.RegisterRoute(nameof(PlantDetailPage), typeof(PlantDetailPage));
			Routing.RegisterRoute(nameof(NewPlantPage), typeof(NewPlantPage));

			Routing.RegisterRoute(nameof(ActionDetailPage), typeof(ActionDetailPage));
			Routing.RegisterRoute(nameof(NewActionPage), typeof(NewActionPage));

			Routing.RegisterRoute(nameof(ResourceDetailPage), typeof(ResourceDetailPage));
			Routing.RegisterRoute(nameof(NewResourcePage), typeof(NewResourcePage));

			Routing.RegisterRoute(nameof(UserCabinetPage), typeof(UserCabinetPage));
			Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
			Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
		}

		private async void OnMenuItemClicked(object sender, EventArgs e)
		{
			var authService = DependencyService.Get<IAuthService>();
			await authService.Logout();

			await Shell.Current.GoToAsync($"{nameof(LoginPage)}");
		}
	}
}
