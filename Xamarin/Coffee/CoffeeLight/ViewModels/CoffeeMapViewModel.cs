using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using Coffee.Services;

namespace CoffeeLight.ViewModels
{
    public class CoffeeMapViewModel : ViewModelBase
    {
		private readonly Record _record;
        private readonly INavigationService _navigationService;

        public CoffeeMapViewModel(Record record, INavigationService navigationService)
        {
            _navigationService = navigationService;
			_record = record;
        }

		public Record Record => _record;
    }
}
