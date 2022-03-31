using Domain.Entities;
using Domain.Entities.WeatherInfo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface IWeatherInfo
    {
        Root GetWeather(string ciudad);
        string GetImageLocation(weather w);
        ForecastInfo GetWeatherForecast();
        DateTime convertToDateTime(long milisegundos);
    }
}
