using PoliceAPI_Client.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliceAPI_Client.Services.Interfaces
{
    public interface ICrimeService
    {
        public Task<IEnumerable<StreetLevelCrime>> GetStreetLevelCrimes(Coordinate coordinate, string date, string category = "all-crime");
        public Task<IEnumerable<StreetLevelCrime>> GetStreetLevelCrimes(Polygon polygon, string date, string category = "all-crime");
        public Task<IEnumerable<StreetLevelOutcome>> GetStreetLevelOutcomes(string date, string locationId);
        public Task<IEnumerable<StreetLevelOutcome>> GetStreetLevelOutcomes(string date, Coordinate coordinate);
        public Task<IEnumerable<StreetLevelOutcome>> GetStreetLevelOutcomes(string date, Polygon polygon);
        public Task<string> GetCrimesAtLocation();
        public Task<string> GetCrimesWithNoLocation();
        public Task<string> GetCrimeCategories();
        public Task<string> GetLastUpdated();
        public Task<string> GetOutcomesForSpecificCrime();
    }
}
