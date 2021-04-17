using SmartGardenMobile.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace SmartGardenMobile.Views
{
	public partial class ItemDetailPage : ContentPage
	{
		public ItemDetailPage()
		{
			InitializeComponent();
			BindingContext = new ItemDetailViewModel();
		}
	}
}