using Coffee.Services;
using GalaSoft.MvvmLight;
using System.Threading.Tasks;

namespace CoffeeUniversal.ViewModels
{
    public class CoffeeMapPageViewModel : ViewModelBase
    {
        public CoffeeMapPageViewModel()
        {

        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task LoadAsync(Record record)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            CenterPoint = new Windows.Devices.Geolocation.Geopoint(
                    new Windows.Devices.Geolocation.BasicGeoposition
                    {
                        Latitude = record.geometry.coordinates[1],
                        Longitude = record.geometry.coordinates[0]
                    });
            Record = record;
        }

        private Windows.Devices.Geolocation.Geopoint _centerPoint;
        public Windows.Devices.Geolocation.Geopoint CenterPoint
        {
            get { return _centerPoint; }
            set { Set(ref _centerPoint, value); }
        }

        private Record _record;
        public Record Record
        {
            get { return _record; }
            set { Set(ref _record, value); }
        }
    }
}
