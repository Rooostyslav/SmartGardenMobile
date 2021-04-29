using SmartGardenMobile.Services;
using SmartGardenMobile.Services.Interfaces;
using Xamarin.Forms;

namespace SmartGardenMobile
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			DependencyService.Register<AuthService>();
			DependencyService.Register<UserService>();
			DependencyService.Register<GardenService>();
			DependencyService.Register<PlantService>();
			DependencyService.Register<ActionService>();
			DependencyService.Register<ResourceService>();

			MainPage = new AppShell();

			Shell.Current.GoToAsync("LoginPage");

			CheckLogin();
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

		private void CheckLogin()
		{
			//var authService = DependencyService.Get<IAuthService>();
			//bool isLogged = authService.IsLogged().Result;

			//if (!isLogged)
			//{
			//	Shell.Current.GoToAsync("LoginPage");
			//}
		}
	}
}
