using Domain.Entities.WeatherInfo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.WeatherForecast
{
    public class daily
    {
        public long dt { get; set; }
        public temp temp { get; set; }
        public List<weather> weather { get; set; }
    }
}
