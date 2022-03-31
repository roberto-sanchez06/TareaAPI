using Domain.Entities;
using Domain.Entities.WeatherInfo;
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

        public DateTime convertToDateTime(long milisegundos)
        {
            return weatherInfo.convertToDateTime(milisegundos);
        }

        public string GetImageLocation(weather w)
        {
            return weatherInfo.GetImageLocation(w);
        }

        public Root GetWeather(string ciudad)
        {
            return weatherInfo.GetWeather(ciudad);
        }

        public ForecastInfo GetWeatherForecast()
        {
            return weatherInfo.GetWeatherForecast();
        }
    }
}
