using SmartGardenMobile.ViewModels.Gardens;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartGardenMobile.Views.Gardens
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GardensListPage : ContentPage
	{
		GardensListViewModel viewModel;

		public GardensListPage()
		{
			InitializeComponent();

			BindingContext = viewModel = new GardensListViewModel();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			viewModel.OnAppearing();
		}
	}
}