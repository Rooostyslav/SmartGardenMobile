using SmartGardenMobile.Models.Plants;
using SmartGardenMobile.ViewModels.Plants;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartGardenMobile.Views.Plants
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewPlantPage : ContentPage
	{
		Plant Plant { get; set; }

		public NewPlantPage()
		{
			InitializeComponent();
			BindingContext = new NewPlantViewModel();
		}
	}
}