using Domain.Entities;
using Domain.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Infraestructure
{
    public class JsonWeatherRepository : IWeatherInfo
    {
        private WeatherInfo.root info;
        private const string APIKEY= "db4fdcfcdeb09e6c36b4ef18af3b59dc";
        public WeatherInfo.root GetWeather(string ciudad)
        {
            using (WebClient web = new WebClient())
            {
                string url = $@"https://api.openweathermap.org/data/2.5/weather?q={ciudad}&appid={APIKEY}";
                var json = web.DownloadString(url);
                info = JsonConvert.DeserializeObject<WeatherInfo.root>(json);
                return info;
            }
        }
        public string GetImageLocation(WeatherInfo.root clima)
        {
            string imageLocation = $@"https://openweathermap.org/img/w/{clima.weather[0].icon}.png";
            return imageLocation;
        }
    }
}
