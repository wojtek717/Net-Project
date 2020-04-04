﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using CityWeather;
//
//    var cityForecast = CityForecast.FromJson(jsonString);

namespace CityWeather
{
    using Newtonsoft.Json;

    public partial class Weather
    {
        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("code")]
        public long Code { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
