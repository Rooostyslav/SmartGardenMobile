using SmartGardenMobile.Models.Resources;
using SmartGardenMobile.Views.Resources;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SmartGardenMobile.ViewModels.Resources
{
	public class ResourcesListViewModel : BaseViewModel
	{
		private ViewResource selectedResource;

		public ObservableCollection<ViewResource> Resources { get; }
		public Command LoadResourcesCommand { get; }
		public Command AddResourceCommand { get; }
		public Command<ViewResource> ResourceTapped { get; }

		public ResourcesListViewModel()
		{
			Title = "Resources List";

			Resources = new ObservableCollection<ViewResource>();

			LoadResourcesCommand = new Command(async () => await ExecuteLoadResourcesCommand());

			ResourceTapped = new Command<ViewResource>(OnResourceSelected);

			AddResourceCommand = new Command(OnAddResource);
		}

		private async Task ExecuteLoadResourcesCommand()
		{
			IsBusy = true;

			try
			{
				Resources.Clear();
				var items = await ResourceService.FindMyResourcesAsync();

				foreach (var item in items)
				{
					Resources.Add(item);
				}

			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}
			finally
			{
				IsBusy = false;
			}
		}

		public void OnAppearing()
		{
			IsBusy = true;
			SelectedResource = null;
		}

		public ViewResource SelectedResource
		{
			get => selectedResource;
			set
			{
				SetProperty(ref selectedResource, value);
				OnResourceSelected(value);
			}
		}

		private async void OnAddResource(object obj)
		{
			await Shell.Current.GoToAsync(nameof(NewResourcePage));
		}

		async void OnResourceSelected(ViewResource resource)
		{
			if (resource == null)
				return;

			await Shell.Current.GoToAsync($"{nameof(ResourceDetailPage)}?{nameof(ResourceDetailViewModel.ResourceId)}={resource.Id}");
		}
	}
}
