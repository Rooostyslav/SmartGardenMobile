using SmartGardenMobile.Views;
using SmartGardenMobile.Views.Gardens;
using SmartGardenMobile.Views.Plants;
using System;
using Xamarin.Forms;

namespace SmartGardenMobile
{
	public partial class AppShell : Shell
	{
		public AppShell()
		{
			InitializeComponent();

			Routing.RegisterRoute(nameof(GardenDetailPage), typeof(GardenDetailPage));
			Routing.RegisterRoute(nameof(NewGardenPage), typeof(NewGardenPage));

			Routing.RegisterRoute(nameof(PlantDetailPage), typeof(PlantDetailPage));
			Routing.RegisterRoute(nameof(NewPlantPage), typeof(NewPlantPage));

			Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
		}

		private async void OnMenuItemClicked(object sender, EventArgs e)
		{
			await Shell.Current.GoToAsync("//LoginPage");
		}
	}
}
