using SmartGardenMobile.Models.Gardens;
using SmartGardenMobile.ViewModels.Gardens;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartGardenMobile.Views.Gardens
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewGardenPage : ContentPage
	{
		public Garden Garden { get; set; }

		public NewGardenPage()
		{
			InitializeComponent();
			BindingContext = new NewGardenViewModel();
		}
	}
}