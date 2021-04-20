using SmartGardenMobile.Models.Resources;
using SmartGardenMobile.ViewModels.Resources;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartGardenMobile.Views.Resources
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewResourcePage : ContentPage
	{
		public Resource Resource { get; set; }

		public NewResourcePage()
		{
			InitializeComponent();

			BindingContext = new NewResourceViewModel();
		}
	}
}