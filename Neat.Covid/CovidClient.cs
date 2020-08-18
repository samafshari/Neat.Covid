using Newtonsoft.Json;

using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Neat.Covid
{
    public class CovidClient
    {
        public async Task<CountryStats> GetCountryStatsAsync(string country)
        {
            var url = $"https://corona.lmao.ninja/v2/countries/{country}?yesterday=true&strict=true";
            var client = new HttpClient();
            var response = await client.GetStringAsync(url);
            return JsonConvert.DeserializeObject<CountryStats>(response);
        }
    }

    public class CountryStats
    {
        public long Updated { get; set; }
        public string Country { get; set; }
        public CountryInfo CountryInfo { get; set; }
        public int Cases { get; set; }
        public int TodayCases { get; set; }
        public int Deaths { get; set; }
        public int TodayDeaths { get; set; }
        public int Recovered { get; set; }
        public int TodayRecovered { get; set; }
        public int Active { get; set; }
        public int Critical { get; set; }
        public double CasesPerOneMillion { get; set; }
        public double DeathsPerOneMillion { get; set; }
        public int Tests { get; set; }
        public double TestsPerOneMillion { get; set; }
        public int Population { get; set; }
        public string Continent { get; set; }
        public double OneCasePerPeople { get; set; }
        public double OneDeathPerPeople { get; set; }
        public double OneTestPerPeople { get; set; }
        public double ActivePerOneMillion { get; set; }
        public double RecoveredPerOneMillion { get; set; }
        public double CriticalPerOneMillion { get; set; }
    }

    public class CountryInfo
    {
        [JsonProperty("_id")] public int Id { get; set; }
        public string Iso2 { get; set; }
        public string Iso3 { get; set; }
        [JsonProperty("lat")] public double Latitude { get; set; }
        [JsonProperty("lng")] public double Longitude { get; set; }
    }
}
