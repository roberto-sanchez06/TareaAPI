﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.WeatherInfo
{
    public class weather
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }
}
