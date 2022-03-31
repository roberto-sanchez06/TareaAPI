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

        public WeatherInfo.root GetWeather(string ciudad)
        {
            return weatherInfo.GetWeather(ciudad);
        }
    }
}
