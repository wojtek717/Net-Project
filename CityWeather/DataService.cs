using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeather
{
    /// <summary>
    /// DataService provides all neccessary function to communicate with data base.
    /// </summary>
    class DataService
    {
        private CityWeatherContext db = new CityWeatherContext();

        public CityWeatherContext Db { get => db; }

        /// <summary>
        /// Function that provides access to every city stored in city datebase.
        /// </summary>
        /// <returns>
        /// Function returns IOrderedQueryable<CityDB> type database query which should be use to get all cities from database.
        /// </returns>
        public IOrderedQueryable<CityDB> getAllCitiesInDBQuery()
        {
            var query = from b in db.Cities
                        orderby b.Name
                        select b;
            return query;
        }
    }
}
