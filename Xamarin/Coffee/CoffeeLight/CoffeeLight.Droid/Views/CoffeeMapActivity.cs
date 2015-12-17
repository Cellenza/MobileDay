using Android.App;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using CoffeeLight.ViewModels;
using GalaSoft.MvvmLight.Views;
using GalaSoft.MvvmLight.Helpers;
using Microsoft.Practices.ServiceLocation;

namespace CoffeeLight.Droid.Views
{
    [Activity(Label = "CoffeeLight.Droid", MainLauncher = false, Icon = "@drawable/icon")]
    public class CoffeeMapActivity
        : ActivityBase, IOnMapReadyCallback
    {
        private MapFragment _mapFragment;
        
        public CoffeeMapViewModel ViewModel { get; private set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.CoffeeMap);
      
            var navigationService = ServiceLocator.Current.GetInstance<INavigationService>() as NavigationService;
            if (navigationService == null)
                return;

            var vm = navigationService.GetAndRemoveParameter<CoffeeMapViewModel>(Intent);
            ViewModel = vm;

            _mapFragment = MapFragment.NewInstance();
            FragmentTransaction tx = FragmentManager.BeginTransaction();
            tx.Add(Resource.Id.map_fragment_container, _mapFragment);
            tx.Commit();
            _mapFragment.GetMapAsync(this);
        }

        public void OnMapReady(GoogleMap map)
        {
            var mapOptions = new GoogleMapOptions()
                .InvokeMapType(GoogleMap.MapTypeNormal)
                .InvokeZoomControlsEnabled(false)
                .InvokeCompassEnabled(true);

            var fragTx = FragmentManager.BeginTransaction();
            _mapFragment = MapFragment.NewInstance(mapOptions);
            fragTx.Add(Resource.Id.map_fragment_container, _mapFragment, "map");
            fragTx.Commit();

            var recordCoordinates = ViewModel?.Record?.geometry?.coordinates;
            var latitude = recordCoordinates?[1];
            var longitude = recordCoordinates?[0];

            var location = new LatLng(latitude ?? 0, longitude ?? 0);
            var builder = CameraPosition.InvokeBuilder();
            builder.Target(location);
            builder.Zoom(18);

            var cameraPosition = builder.Build();
            var cameraUpdate = CameraUpdateFactory.NewCameraPosition(cameraPosition);

            map.MoveCamera(cameraUpdate);

            var markerOpt1 = new MarkerOptions();
            markerOpt1.SetPosition(location);
            markerOpt1.SetTitle(ViewModel?.Record?.fields?.nom_du_cafe ?? string.Empty);
            map.AddMarker(markerOpt1);
        }

        protected override void OnDestroy()
        {
            if (_mapFragment != null)
            {
                FragmentManager.PopBackStackImmediate("map", PopBackStackFlags.Inclusive);
            }

            base.OnDestroy();
        }
    }
}