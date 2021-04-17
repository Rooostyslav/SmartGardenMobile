using SmartGardenMobile.ViewModels.Plants;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartGardenMobile.Views.Plants
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PlantsListPage : ContentPage
	{
		PlantsListViewModel viewModel;

		public PlantsListPage()
		{
			InitializeComponent();

			BindingContext = viewModel = new PlantsListViewModel();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			viewModel.OnAppearing();
		}
	}
}