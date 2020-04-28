namespace CityWeather
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    using System.Linq;
    using CityWeather;


    /// <summary>
    /// Database is made with the help of LocalDB. To first initialize the database:
    /// -- Make sure you have the right reference in the 'App.config' file
    /// -- Using Visual Studio, go to 'View' -> 'Server Explorer' -> Right click on 'Data Connections' -> 'Add Connection'
    /// -- in the 'Server Name' field, paste following '(LocalDb)\MSSQLLocalDB'
    /// -- in the 'Select or enter a database name' choose 'CityWeather.Model'
    /// -- Confirm by clicking ok. Your local database should be set up.
    /// </summary>


    /// <summary>
    /// Context needed for the database made using Entity Framework Code First approach.
    /// </summary>
    public class CityWeatherContext : DbContext
    {
        public CityWeatherContext() : base("name=CityWeatherDB")
        {
        }

        public DbSet<CityDB> Cities { get; set; }
    }

    /// <summary>
    /// Database class made using Entity Framework Code First approach. Holds City' Names and assigns them unique ID.
    /// </summary>
    public class CityDB
    {
        [Key]
        public int CityId { get; set; }
        public string Name { get; set; }

    }

}