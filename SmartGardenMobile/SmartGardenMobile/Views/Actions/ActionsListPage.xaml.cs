using SmartGardenMobile.ViewModels.Actions;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartGardenMobile.Views.Actions
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ActionsListPage : ContentPage
	{
		ActionsListViewModel viewModel;
		
		public ActionsListPage()
		{
			InitializeComponent();
			BindingContext = viewModel = new ActionsListViewModel();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			viewModel.OnAppearing();
		}
	}
}