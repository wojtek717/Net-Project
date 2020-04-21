namespace CityWeather
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    using System.Linq;
    using CityWeather;


        
    public class CityWeatherContext : DbContext
    {
        public CityWeatherContext() : base("name=CityWeatherDB")
        {
        }

        public DbSet<CityDB> Cities { get; set; }
        public DbSet<CityTemperature> Temperatures { get; set; }

    }

    public class CityDB
    {
        [Key]
        public int CityId { get; set; }
        public string Name { get; set; }

        public virtual List<CityTemperature> CityTemperature { get; set; }
    }

    public class CityTemperature
    {
        [Key]
        public int TemperatureId { get; set; }
        public int Temperature { get; set; }
        public DateTime TemperatureDate { get; set; }

        public int CityId { get; set; }
        public virtual CityDB CityDB { get; set; }
    }

}