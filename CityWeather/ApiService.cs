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
        string sAttr;

        public ApiService()
        {
            sAttr = ConfigurationManager.AppSettings.Get("APIKEY");
        }
    }
}
