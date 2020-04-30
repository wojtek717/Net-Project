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
    /// <summary>
    /// ApiService provides all neccessary methods and parameters needed to 
    /// connect and receive data from weather API
    /// </summary>
    class ApiService
    {
        string apiKey;
        string apiBaseUrlForecast;
        string apiBaseUrlCurrentWeather;

        string countryShort = "PL";

        static HttpClient client = new HttpClient();

        /// <summary>
        /// Constructor provides every API KEY from App.config
        /// </summary>
        public ApiService()
        {
            apiKey = ConfigurationManager.AppSettings.Get("APIKEY");
            apiBaseUrlForecast = ConfigurationManager.AppSettings.Get("APIURLFORECAST");
            apiBaseUrlCurrentWeather = ConfigurationManager.AppSettings.Get("APIURLCURRENT");
        }

        /// <summary>
        /// Function check response from API for provided city name
        /// </summary>
        /// <param name="city">
        /// City name for which weather data will be requested
        /// </param>
        /// <returns>
        /// Return HttpWebResponse which provides request response code.
        /// </returns>
         public HttpWebResponse CheckApiResponse(string city) {
            HttpWebRequest httpReq = (HttpWebRequest)WebRequest.Create(apiBaseUrlCurrentWeather + city + "," + countryShort + "&key=" + apiKey);
            httpReq.AllowAutoRedirect = false;

            try {
                HttpWebResponse httpRes = (HttpWebResponse)httpReq.GetResponse();
                httpRes.Close();

                return httpRes;
            }
            catch(Exception e) {
                Console.WriteLine(e);
                return null;
            }

        }

        /// <summary>
        /// Function provides connection to API service and ask for forecast data for specific city and
        /// given number of days.
        /// </summary>
        /// <param name="city">
        /// City name for which forecast data will be requested.
        /// </param>
        /// <param name="days">
        /// Number of days for wich forecaste data will be requested.
        /// </param>
        /// <returns>
        /// Returns async operation which can contain CityForecast data after correct API response.
        /// </returns>
        public async Task<CityForecast> GetCityForecast(string city, int days) {
            var json = await client.GetStringAsync(apiBaseUrlForecast + city + "," + countryShort + "&key=" + apiKey + "&days=" + (days.ToString()));
            var cityForecast = CityForecast.FromJson(json);
            Console.WriteLine(apiBaseUrlForecast + city + "," + countryShort + "&key=" + apiKey + "&days=" + (days.ToString()));

            return cityForecast;
        }

        /// <summary>
        /// Function provides connection to API service and ask for weather data for specific city.
        /// </summary>
        /// <param name="city">
        /// City name for which weather data will be requested.
        /// </param>
        /// <returns>
        /// Returns async operation which can contain CityWeather data after correct API response.
        /// </returns>
        public async Task<CityCurrentWeather> GetCityCurrentWeather(string city) {
            var json = await client.GetStringAsync(apiBaseUrlCurrentWeather + city + "," + countryShort + "&key=" + apiKey);
            var cityCurrentWeather = CityCurrentWeather.FromJson(json);

            return cityCurrentWeather;
        }
    }
}
