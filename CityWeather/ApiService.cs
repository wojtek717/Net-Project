using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Specialized;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace CityWeather
{
    class ApiService
    {
        string apiKey;
        string apiBaseUrl;

        string countryShort = "PL";

        static HttpClient client = new HttpClient();

        public ApiService()
        {
            apiKey = ConfigurationManager.AppSettings.Get("APIKEY");
            apiBaseUrl = ConfigurationManager.AppSettings.Get("APIURL");
        }


        public async Task<CityForecast> GetCityForecast(string city, int days) {
            var json = await client.GetStringAsync(apiBaseUrl + city + "," + countryShort + "&key=" + apiKey + "&days=" + (days.ToString()));
            var cityForecast = CityForecast.FromJson(json);

            return cityForecast;
        }
    }
}
