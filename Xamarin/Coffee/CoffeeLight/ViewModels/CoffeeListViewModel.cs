using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using Coffee.Services;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;

namespace CoffeeLight.ViewModels
{
    public class CoffeeListViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
		private readonly ICoffeeService _coffeeService;

        public CoffeeListViewModel(ICoffeeService coffeeService, INavigationService navigationService)
        {
            _navigationService = navigationService;
			_coffeeService = coffeeService;
			SelectRecord = new RelayCommand<Record> (ExecuteSelectRecord);
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
			set { Set (ref _records, value);}
		}

		public RelayCommand<Record> SelectRecord { get; }

		private void ExecuteSelectRecord(Record record)
		{
			_navigationService.NavigateTo(ViewModelLocator.MapPageKey, new CoffeeMapViewModel(record, _navigationService));
		}
    }
}
