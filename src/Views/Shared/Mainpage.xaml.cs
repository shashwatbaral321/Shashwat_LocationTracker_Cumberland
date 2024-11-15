using LocationTracker.Models;
using LocationTracker.Services;
using Microsoft.Maui.Controls.Maps;
using System.Collections.Generic;
using System.Linq;

namespace LocationTracker
{
    public partial class MainPage : ContentPage
    {
        private readonly LocationService _locationService;
        private readonly DatabaseService _databaseService;
        
        public MainPage()
        {
            InitializeComponent();
            _locationService = new LocationService();
            _databaseService = new DatabaseService();
        }

        private async void OnStartTrackingClicked(object sender, EventArgs e)
        {
            var location = await _locationService.GetCurrentLocationAsync();
            if (location != null)
            {
                await _databaseService.SaveLocationAsync(location);
                UpdateHeatMap();
            }
        }

        private async void UpdateHeatMap()
        {
            var locations = await _databaseService.GetLocationsAsync();
            foreach (var loc in locations)
            {
                var position = new Position(loc.Latitude, loc.Longitude);
                LocationMap.Pins.Add(new Pin { Position = position });
            }
        }
    }
}
