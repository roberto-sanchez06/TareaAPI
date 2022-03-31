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
        WeatherInfo.root info;

        public JsonWeatherRepository(WeatherInfo.root info)
        {
            info = new WeatherInfo.root();
        }

        public WeatherInfo.root GetWeather(string ciudad)
        {
            using (WebClient web = new WebClient())
            {
                string url = $@"https://api.openweathermap.org/data/2.5/weather?q={ciudad}&appid=db4fdcfcdeb09e6c36b4ef18af3b59dc";
                var json = web.DownloadString(url);
                info = JsonConvert.DeserializeObject<WeatherInfo.root>(json);
                return info;
            }
        }
    }
}
