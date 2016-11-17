using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;

namespace NKitchen
{
    [Activity(Label = "Maps")]
    public class MapsActivity : Activity
    {
        private Button externalBtn;
        private FrameLayout mapsFrame;
        private MapFragment mapFragment;
        private GoogleMap googleMap;
        private LatLng latLng;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.MapsLayout);
            latLng = new LatLng(31.465903, 74.272831);
            Find_Views();
            Attach_Events();
            CreateMapFragment();
            Update_View();
        }

        private void Update_View()
        {
            var mapReadyCallback = new LocalMapReady();

            mapReadyCallback.MapReady += (sender, args) =>
            {
                googleMap = (sender as LocalMapReady).Map;
                if (googleMap != null)
                {
                    MarkerOptions markerOptions = new MarkerOptions();
                    markerOptions.SetPosition(latLng);
                    markerOptions.SetTitle("Imran Aftab");
                    googleMap.AddMarker(markerOptions);

                    CameraUpdate cameraUpdate = CameraUpdateFactory.NewLatLngZoom(latLng,15);
                    googleMap.MoveCamera(cameraUpdate);

                }
            };

            mapFragment.GetMapAsync(mapReadyCallback);
        }

        private void Attach_Events()
        {

        }

        private void CreateMapFragment()
        {
            mapFragment = (MapFragment)FragmentManager.FindFragmentByTag("map");
            if (mapFragment == null)
            {
                GoogleMapOptions mapOptions = new GoogleMapOptions()
                                                .InvokeMapType(GoogleMap.MapTypeNormal)
                                                .InvokeZoomControlsEnabled(false)
                                                .InvokeCompassEnabled(true);
                FragmentTransaction fragTx = FragmentManager.BeginTransaction();
                mapFragment = MapFragment.NewInstance(mapOptions);
                fragTx.Add(Resource.Id.mapsFrame, mapFragment, "map");
                fragTx.Commit();
            }
        }

        private void Find_Views()
        {
            externalBtn = FindViewById<Button>(Resource.Id.externalBtn);
            mapsFrame = FindViewById<FrameLayout>(Resource.Id.mapsFrame);
        }
        private class LocalMapReady : Java.Lang.Object, IOnMapReadyCallback
        {
            public GoogleMap Map { get; private set; }
            public event EventHandler MapReady;

            public void OnMapReady(GoogleMap googleMap)
            {
                Map = googleMap;
                var handler = MapReady;
                if (handler != null)
                    handler(this, EventArgs.Empty);
            }
        }
    }
}