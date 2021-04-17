using SmartGardenMobile.Services;
using Xamarin.Forms;

namespace SmartGardenMobile
{
	public partial class App : Application
	{

		public App()
		{
			InitializeComponent();

			DependencyService.Register<UserService>();
			DependencyService.Register<GardenService>();
			DependencyService.Register<PlantService>();

			MainPage = new AppShell();
		}

		protected override void OnStart()
		{
		}

		protected override void OnSleep()
		{
		}

		protected override void OnResume()
		{
		}
	}
}
