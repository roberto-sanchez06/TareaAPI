using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface IWeatherInfo
    {
        WeatherInfo.root GetWeather(string ciudad);
        string GetImageLocation(WeatherInfo.root clima);
    }
}
