using Domain.Entities;
using Domain.Entities.WeatherInfo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Interface
{
    public interface IWheaterService
    {
        Root GetWeather(string ciudad);
        string GetImageLocation(weather w);
        ForecastInfo GetWeatherForecast();
        DateTime convertToDateTime(long milisegundos);
    }
}
