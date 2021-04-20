using SmartGardenMobile.ViewModels.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartGardenMobile.Views.Resources
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ResourceDetailPage : ContentPage
	{
		public ResourceDetailPage()
		{
			InitializeComponent();
			BindingContext = new ResourceDetailViewModel();
		}
	}
}