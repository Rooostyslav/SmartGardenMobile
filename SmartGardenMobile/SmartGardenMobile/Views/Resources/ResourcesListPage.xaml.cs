using SmartGardenMobile.ViewModels.Resources;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartGardenMobile.Views.Resources
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ResourcesListPage : ContentPage
	{
		ResourcesListViewModel viewModel;

		public ResourcesListPage()
		{
			InitializeComponent();
			BindingContext = viewModel = new ResourcesListViewModel();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			viewModel.OnAppearing();
		}
	}
}