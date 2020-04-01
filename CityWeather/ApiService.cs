using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Specialized;

namespace CityWeather
{
    class ApiService
    {
        string apiKey;

        public ApiService()
        {
            apiKey = ConfigurationManager.AppSettings.Get("APIKEY");
        }
    }
}
