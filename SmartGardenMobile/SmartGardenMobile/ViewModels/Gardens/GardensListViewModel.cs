﻿using SmartGardenMobile.Models.Gardens;
using SmartGardenMobile.Views.Gardens;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SmartGardenMobile.ViewModels.Gardens
{
	public class GardensListViewModel : BaseViewModel
	{
		private Garden selectedGarden;

		public ObservableCollection<Garden> Gardens { get; }
		public Command LoadGardensCommand { get; }
		public Command AddGardenCommand { get; }
		public Command<Garden> GardenTapped { get; }

		public GardensListViewModel()
		{
			Title = "Gardens List";

			Gardens = new ObservableCollection<Garden>();

			LoadGardensCommand = new Command(async () => await ExecuteLoadGardensCommand());

			GardenTapped = new Command<Garden>(OnGardenSelected);

			AddGardenCommand = new Command(OnAddGarden);
		}

		async Task ExecuteLoadGardensCommand()
		{
			IsBusy = true;

			try
			{
				Gardens.Clear();
				var gardens = await GardenService.FindGardensByUserAsync(2);

				foreach(var garden in gardens)
				{
					Gardens.Add(garden);
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
			SelectedGarden = null;
		}

		public Garden SelectedGarden
		{
			get => selectedGarden;
			set
			{
				SetProperty(ref selectedGarden, value);
				OnGardenSelected(value);
			}
		}

		private async void OnAddGarden(object obj)
		{
			await Shell.Current.GoToAsync(nameof(NewGardenPage));
		}

		async void OnGardenSelected(Garden garden)
		{
			if (garden == null)
				return;

			await Shell.Current.GoToAsync($"{nameof(GardenDetailPage)}?{nameof(GardenDetailViewModel.GardenId)}={garden.Id}");
		}
	}
}