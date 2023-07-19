using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PoliceAPI_Client.Common;
using PoliceAPI_Client.Models;
using PoliceAPI_Client.Services.Interfaces;

namespace PoliceAPI_Client.Services.Implementations
{
    public class CrimeService : BaseService, ICrimeService
    {
        public Task<string> GetCrimeCategories()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetCrimesAtLocation()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetCrimesWithNoLocation()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetLastUpdated()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetOutcomesForSpecificCrime()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<StreetLevelCrime>> GetStreetLevelCrimes(Coordinate coordinate, string date, string category = "all-crime")
        {
            string latlng = string.Format(CultureInfo.InvariantCulture, "lat={0}&lng={1}", coordinate.Latitude, coordinate.Longitude);
            var crimes = await GetList<StreetLevelCrime>($"crimes-street/{category}?{latlng}&date={date}");
            return crimes;
        }

        public async Task<IEnumerable<StreetLevelCrime>> GetStreetLevelCrimes(Polygon polygon, string date, string category = "all-crime")
        {
            var crimes = await GetList<StreetLevelCrime>($"crimes-street/{category}?poly={polygon}&date={date}");
            return crimes;
        }

        public async Task<IEnumerable<StreetLevelOutcome>> GetStreetLevelOutcomes(string date, string locationId)
        {
            var outcomes = await GetList<StreetLevelOutcome>($"crimes-street/outcomes-at-location?date={date}&location_id={locationId}");
            return outcomes;
        }
        public async Task<IEnumerable<StreetLevelOutcome>> GetStreetLevelOutcomes(string date, Coordinate coordinate)
        {
            string latlng = string.Format(CultureInfo.InvariantCulture, "lat={0}&lng={1}", coordinate.Latitude, coordinate.Longitude);
            var outcomes = await GetList<StreetLevelOutcome>($"crimes-street/outcomes-at-location?date={date}&{latlng}");
            return outcomes;
        }
        public async Task<IEnumerable<StreetLevelOutcome>> GetStreetLevelOutcomes(string date, Polygon polygon)
        {
            var outcomes = await GetList<StreetLevelOutcome>($"crimes-street/outcomes-at-location?date={date}&poly={polygon}");
            return outcomes;
        }
    }
}
