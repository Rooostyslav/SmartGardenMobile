using SmartGardenMobile.Models.Actions;
using SmartGardenMobile.ViewModels.Actions;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartGardenMobile.Views.Actions
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewActionPage : ContentPage
	{
		public Action Action;

		public NewActionPage()
		{
			InitializeComponent();
			BindingContext = new NewActionViewModel();
		}
	}
}