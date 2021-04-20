using SmartGardenMobile.ViewModels.Actions;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartGardenMobile.Views.Actions
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ActionDetailPage : ContentPage
	{
		public ActionDetailPage()
		{
			InitializeComponent();
			BindingContext = new ActionDetailViewModel();
		}
	}
}