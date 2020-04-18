namespace CityWeather
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    using System.Linq;


        
    public class CityWeatherContext : DbContext
    {
        public CityWeatherContext() : base("name=CityWeatherDB")
        {
        }

        public DbSet<CityDB> Cities { get; set; }

    }

    public class CityDB
    {
        [Key]
        public int CityId { get; set; }
        public string Name { get; set; }
        public int WeatherData { get; set; }
    }

}