﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using CityWeather;
//
//    var cityCurrentWeather = CityCurrentWeather.FromJson(jsonString);

namespace CityWeather
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class CityCurrentWeather
    {
        [JsonProperty("data")]
        public List<DatumCurrent> Data { get; set; }

        [JsonProperty("count")]
        public long Count { get; set; }
    }

    public partial class DatumCurrent
    {
        [JsonProperty("rh")]
        public long Rh { get; set; }

        [JsonProperty("pod")]
        public string Pod { get; set; }

        [JsonProperty("lon")]
        public double Lon { get; set; }

        [JsonProperty("pres")]
        public double Pres { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("ob_time")]
        public string ObTime { get; set; }

        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        [JsonProperty("clouds")]
        public long Clouds { get; set; }

        [JsonProperty("ts")]
        public long Ts { get; set; }

        [JsonProperty("solar_rad")]
        public double SolarRad { get; set; }

        [JsonProperty("state_code")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long StateCode { get; set; }

        [JsonProperty("city_name")]
        public string CityName { get; set; }

        [JsonProperty("wind_spd")]
        public double WindSpd { get; set; }

        [JsonProperty("last_ob_time")]
        public DateTimeOffset LastObTime { get; set; }

        [JsonProperty("wind_cdir_full")]
        public string WindCdirFull { get; set; }

        [JsonProperty("wind_cdir")]
        public string WindCdir { get; set; }

        [JsonProperty("slp")]
        public double Slp { get; set; }

        [JsonProperty("vis")]
        public double Vis { get; set; }

        [JsonProperty("h_angle")]
        public double HAngle { get; set; }

        [JsonProperty("sunset")]
        public string Sunset { get; set; }

        [JsonProperty("dni")]
        public double Dni { get; set; }

        [JsonProperty("dewpt")]
        public long Dewpt { get; set; }

        [JsonProperty("snow")]
        public long Snow { get; set; }

        [JsonProperty("uv")]
        public double Uv { get; set; }

        [JsonProperty("precip")]
        public long Precip { get; set; }

        [JsonProperty("wind_dir")]
        public long WindDir { get; set; }

        [JsonProperty("sunrise")]
        public string Sunrise { get; set; }

        [JsonProperty("ghi")]
        public double Ghi { get; set; }

        [JsonProperty("dhi")]
        public double Dhi { get; set; }

        [JsonProperty("aqi")]
        public long Aqi { get; set; }

        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("weather")]
        public Weather Weather { get; set; }

        [JsonProperty("datetime")]
        public string Datetime { get; set; }

        [JsonProperty("temp")]
        public double Temp { get; set; }

        [JsonProperty("station")]
        public string Station { get; set; }

        [JsonProperty("elev_angle")]
        public double ElevAngle { get; set; }

        [JsonProperty("app_temp")]
        public double AppTemp { get; set; }
    }


    public partial class CityCurrentWeather
    {
        public static CityCurrentWeather FromJson(string json) => JsonConvert.DeserializeObject<CityCurrentWeather>(json, CityWeather.Converter.Settings);
    }

    public static class SerializeCurrentWeather
    {
        public static string ToJson(this CityCurrentWeather self) => JsonConvert.SerializeObject(self, CityWeather.Converter.Settings);
    }
}
