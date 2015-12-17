using System;
using Cirrious.MvvmCross.ViewModels;
using Coffee.Services;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace CoffeeCross
{
	public class CoffeeListViewModel : MvxViewModel
	{
		private readonly ICoffeeService _coffeeService;

		public CoffeeListViewModel(ICoffeeService coffeeService)
		{
			_coffeeService = coffeeService;
			SelectRecord = new MvxCommand<Record> (ExecuteSelectRecord);
		}

		public override async void Start ()
		{
			try
			{
				await StartAsync();
			}
			catch
			{
				// TODO : Handle errors
			}
		}

		public async Task StartAsync()
		{
			await _coffeeService.InitializeAsync();
			Records = new ObservableCollection<Record>(_coffeeService.Records);
		}

		private ObservableCollection<Record> _records;
		public ObservableCollection<Record> Records
		{
			get { return _records; }
			set { SetProperty(ref _records, value); }
		}

		public MvxCommand<Record> SelectRecord { get; }

		private void ExecuteSelectRecord(Record record)
		{
		    if (record?.geometry == null)
		        return;

			var recordCoordinates = record.geometry.coordinates;
			var latitude = recordCoordinates[1];
			var longitude = recordCoordinates[0];
			var title = record.fields.nom_du_cafe;
			var subtitle = record.fields.adresse;

			var parameter = new CoffeeMapViewModel.Parameter(latitude, longitude, title, subtitle);

			ShowViewModel<CoffeeMapViewModel>(parameter);
		}
	}
}

