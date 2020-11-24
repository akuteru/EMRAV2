using Xamarin.Forms;
using System.Reflection;
using Xamarin.Essentials;
using Xamarin.Forms.GoogleMaps;

namespace EMRA.Views
{
    public partial class MapPage : ContentPage
    {
        public MapPage()
        {
            InitializeComponent();
            ApplyMapTheme();
            CenterToCurrentlocation();
        }
        private void ApplyMapTheme()
        {
            var assembly = typeof(MapPage).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream("EMRA.Resources.MapStyle.json");
            string styleData;
            using (var reader = new System.IO.StreamReader(stream))
            {
                styleData = reader.ReadToEnd();
                medicalMap.MapStyle = MapStyle.FromJson(styleData);
            }
        }
        private async void CenterToCurrentlocation()
        {
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();
                medicalMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(location.Latitude, location.Longitude), Distance.FromMeters(5000)).WithZoom(5));
            }
            catch(PermissionException pEx)
            {
                //Do some catching
            }
        }
    }
}
