using Domain.Entities;
using Domain.Interfaces;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Service
{
    public class WeatherService : IWheaterService
    {

        private IWeatherInfo weatherInfo;

        public WeatherService(IWeatherInfo weatherInfo)
        {
            this.weatherInfo = weatherInfo;
        }

        public string GetImageLocation(WeatherInfo.root clima)
        {
            return weatherInfo.GetImageLocation(clima);
        }

        public WeatherInfo.root GetWeather(string ciudad)
        {
            return weatherInfo.GetWeather(ciudad);
        }
    }
}
