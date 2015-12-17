using Android.App;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Views;
using Cirrious.MvvmCross.Binding.Droid.BindingContext;
using Cirrious.MvvmCross.Droid.FullFragging.Fragments;

namespace CoffeeCross.Droid.Views
{
    public class CoffeeMapView
        : MvxFragment<CoffeeMapViewModel>, IOnMapReadyCallback
    {
        private MapFragment _mapFragment;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = this.BindingInflate(Resource.Layout.CoffeeMapFragment, null);

            _mapFragment = MapFragment.NewInstance();
            FragmentTransaction tx = FragmentManager.BeginTransaction();
            tx.Add(Resource.Id.map_fragment_container, _mapFragment);
            tx.Commit();

            _mapFragment.GetMapAsync(this);

            return view;
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

            var location = new LatLng(ViewModel.Latitude ?? 0, ViewModel.Longitude ?? 0);
            var builder = CameraPosition.InvokeBuilder();
            builder.Target(location);
            builder.Zoom(18);

            var cameraPosition = builder.Build();
            var cameraUpdate = CameraUpdateFactory.NewCameraPosition(cameraPosition);

            map.MoveCamera(cameraUpdate);

            var markerOpt1 = new MarkerOptions();
            markerOpt1.SetPosition(location);
            markerOpt1.SetTitle(ViewModel.Title);
            map.AddMarker(markerOpt1);
        }

        public override void OnDestroyView()
        {
            if (_mapFragment != null)
            {
                FragmentManager.PopBackStackImmediate("map", PopBackStackFlags.Inclusive);
            }

            base.OnDestroyView();
        }
    }
}