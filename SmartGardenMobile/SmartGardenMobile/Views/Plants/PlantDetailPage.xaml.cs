using SmartGardenMobile.ViewModels.Plants;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartGardenMobile.Views.Plants
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PlantDetailPage : ContentPage
	{
		public PlantDetailPage()
		{
			InitializeComponent();
			BindingContext = new PlantDetailViewModel();
		}
	}
}