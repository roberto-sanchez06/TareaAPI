using Domain.Entities.WeatherForecast;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class ForecastInfo
    {
        public List<daily> daily { get; set; }
    }
}
