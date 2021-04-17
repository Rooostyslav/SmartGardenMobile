using SmartGardenMobile.Models.Plants;
using SmartGardenMobile.Views.Plants;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SmartGardenMobile.ViewModels.Plants
{
	public class PlantsListViewModel : BaseViewModel
	{
		private Plant selectedPlant;

		public ObservableCollection<Plant> Plants { get; }
		public Command LoadPlantsCommand { get; }
		public Command AddPlantCommand { get; }
		public Command<Plant> PlantTapped { get; }

		public PlantsListViewModel()
		{
			Title = "Gardens List";

			Plants = new ObservableCollection<Plant>();

			LoadPlantsCommand = new Command(async () => await ExecuteLoadPlantsCommand());

			PlantTapped = new Command<Plant>(OnPlantSelected);

			AddPlantCommand = new Command(OnAddPlant);
		}

		async Task ExecuteLoadPlantsCommand()
		{
			IsBusy = true;

			try
			{
				Plants.Clear();
				var items = await PlantService.FindPlantsByUserAsync(2);

				foreach (var item in items)
				{
					Plants.Add(item);
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
			SelectedPlant = null;
		}

		public Plant SelectedPlant
		{
			get => selectedPlant;
			set
			{
				SetProperty(ref selectedPlant, value);
				OnPlantSelected(value);
			}
		}

		private async void OnAddPlant(object obj)
		{
			await Shell.Current.GoToAsync(nameof(NewPlantPage));
		}

		async void OnPlantSelected(Plant plant)
		{
			if (plant == null)
				return;

			await Shell.Current.GoToAsync($"{nameof(PlantDetailPage)}?{nameof(PlantDetailViewModel.PlantId)}={plant.Id}");
		}
	}
}
