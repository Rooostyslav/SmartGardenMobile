using SmartGardenMobile.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartGardenMobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UserCabinetPage : ContentPage
	{
		public UserCabinetPage()
		{
			InitializeComponent();
			BindingContext = new UserCabinetViewModel();
		}
	}
}