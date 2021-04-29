using SmartGardenMobile.Models.Actions;
using SmartGardenMobile.Views.Actions;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SmartGardenMobile.ViewModels.Actions
{
	public class ActionsListViewModel : BaseViewModel
	{
		private ViewAction selectedAction;

		public ObservableCollection<ViewAction> Actions { get; }
		public Command LoadActionsCommand { get; }
		public Command AddActionCommand { get; }
		public Command<ViewAction> ActionTapped { get; }

		public ActionsListViewModel()
		{
			Actions = new ObservableCollection<ViewAction>();

			LoadActionsCommand = new Command(async () => await ExecuteLoadActionsCommand());

			ActionTapped = new Command<ViewAction>(OnActionSelected);

			AddActionCommand = new Command(OnAddAction);
		}

		async Task ExecuteLoadActionsCommand()
		{
			IsBusy = true;

			try
			{
				Actions.Clear();
				var actions = await ActionService.FindMyActionsAsync();

				foreach (var action in actions)
				{
					Actions.Add(action);
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
			SelectedAction = null;
		}

		public ViewAction SelectedAction
		{
			get => selectedAction;
			set
			{
				SetProperty(ref selectedAction, value);
				OnActionSelected(value);
			}
		}

		private async void OnAddAction(object obj)
		{
			await Shell.Current.GoToAsync(nameof(NewActionPage));
		}

		async void OnActionSelected(ViewAction action)
		{
			if (action == null)
				return;

			await Shell.Current.GoToAsync($"{nameof(ActionDetailPage)}?{nameof(ActionDetailViewModel.ActionId)}={action.Id}");
		}
	}
}
