using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Interface
{
    public interface IWheaterService
    {
        WeatherInfo.root GetWeather(string ciudad);
    }
}
