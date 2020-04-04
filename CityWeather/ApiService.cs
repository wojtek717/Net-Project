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
        string apiBaseUrlForecast;
        string apiBaseUrlCurrentWeather;

        string countryShort = "PL";

        static HttpClient client = new HttpClient();

        public ApiService()
        {
            apiKey = ConfigurationManager.AppSettings.Get("APIKEY");
            apiBaseUrlForecast = ConfigurationManager.AppSettings.Get("APIURLFORECAST");
            apiBaseUrlCurrentWeather = ConfigurationManager.AppSettings.Get("APIURLCURRENT");
        }


        public async Task<CityForecast> GetCityForecast(string city, int days) {
            var json = await client.GetStringAsync(apiBaseUrlForecast + city + "," + countryShort + "&key=" + apiKey + "&days=" + (days.ToString()));
            var cityForecast = CityForecast.FromJson(json);

            return cityForecast;
        }

        public async Task<CityCurrentWeather> GetCityCurrentWeather(string city) {
            var json = await client.GetStringAsync(apiBaseUrlCurrentWeather + city + "," + countryShort + "&key=" + apiKey);
            var cityCurrentWeather = CityCurrentWeather.FromJson(json);

            return cityCurrentWeather;
        }
    }
}
