using LocationTracker.Models;
using Microsoft.Maui.Devices.Sensors;

namespace LocationTracker.Services
{
    public class LocationService
    {
        public async Task<LocationModel> GetCurrentLocationAsync()
        {
            var location = await Geolocation.Default.GetLocationAsync();
            if (location != null)
            {
                return new LocationModel
                {
                    Latitude = location.Latitude,
                    Longitude = location.Longitude,
                    Timestamp = DateTime.Now
                };
            }
            return null;
        }
    }
}
