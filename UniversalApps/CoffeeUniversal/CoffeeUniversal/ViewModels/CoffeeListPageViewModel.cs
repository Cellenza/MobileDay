using Coffee.Services;
using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeUniversal.ViewModels
{
    public class CoffeeListPageViewModel : ViewModelBase
    {
        private readonly ICoffeeService _coffeeService;
        private ICoffeeListModeHandler _coffeeListModeHandler;

        public CoffeeListPageViewModel(ICoffeeService coffeeService)
        {
            _coffeeService = coffeeService;
        }

        private IReadOnlyList<Record> _records;
        public IReadOnlyList<Record> Records
        {
            get { return _records; }
            set { base.Set(ref _records, value); }
        }

        private Windows.Devices.Geolocation.Geopoint _centerPoint;
        public Windows.Devices.Geolocation.Geopoint CenterPoint
        {
            get { return _centerPoint; }
            set { Set(ref _centerPoint, value); }
        }

        private Record _selectedRecord;
        public Record SelectedRecord
        {
            get { return _selectedRecord; }
            set
            {
                if (Set(ref _selectedRecord, value))
                {
                    if (_selectedRecord.geometry != null)
                    {
                        CenterPoint = new Windows.Devices.Geolocation.Geopoint(
                            new Windows.Devices.Geolocation.BasicGeoposition
                            {
                                Latitude = _selectedRecord.geometry.coordinates[1],
                                Longitude = _selectedRecord.geometry.coordinates[0]
                            });
                    }

                    if (DisplayMode)
                    {
                        _coffeeListModeHandler.NavigateToDetailView();
                    }
                    else
                    {
                        _coffeeListModeHandler.ShowDetailView();
                    }
                }
            }
        }

        private bool _displayMode;
        public bool DisplayMode
        {
            get { return _displayMode; }
            set { Set(ref _displayMode, value); }
        }

        public async Task LoadAsync(ICoffeeListModeHandler coffeeListModeHandler)
        {
            _coffeeListModeHandler = coffeeListModeHandler;
            await _coffeeService.InitializeAsync();
            Records = _coffeeService.Records;
            SelectedRecord = Records.FirstOrDefault();
        }
    }
}
