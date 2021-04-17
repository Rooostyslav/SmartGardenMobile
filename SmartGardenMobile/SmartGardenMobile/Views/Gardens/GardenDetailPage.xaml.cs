using SmartGardenMobile.ViewModels.Gardens;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartGardenMobile.Views.Gardens
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GardenDetailPage : ContentPage
	{
		public GardenDetailPage()
		{
			InitializeComponent();
			BindingContext = new GardenDetailViewModel();
		}
	}
}