using SmartGardenMobile.Models.Users;
using SmartGardenMobile.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartGardenMobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegisterPage : ContentPage
	{
		public User User;

		public RegisterPage()
		{
			InitializeComponent();
			BindingContext = new RegisterViewModel();
		}
	}
}