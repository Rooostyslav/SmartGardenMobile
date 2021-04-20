using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace SmartGardenMobile.ViewModels.Actions
{
	[QueryProperty(nameof(ActionId), nameof(ActionId))]
	public class ActionDetailViewModel : BaseViewModel
	{
		private int actionId;
		private string name;
		private bool status;
		private DateTime date;

		public int Id { get; set; }

		public string Name
		{
			get => name;
			set => SetProperty(ref name, value);
		}

		public bool Status
		{
			get => status;
			set => SetProperty(ref status, value);
		}

		public DateTime Date
		{
			get => date;
			set => SetProperty(ref date, value);
		}

		public int ActionId
		{
			get
			{
				return actionId;
			}
			set
			{
				actionId = value;
				LoadActionId(value);
			}
		}

		public async void LoadActionId(int actionId)
		{
			try
			{
				var action = await ActionService.FindActionByIdAsync(actionId);
				Id = action.Id;
				Name = action.Name;
				Status = action.Status;
				Date = action.Date;
			}
			catch (Exception)
			{
				Debug.WriteLine("Failed to Load Item");
			}
		}
	}
}
