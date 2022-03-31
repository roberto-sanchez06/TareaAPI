using Autofac;
using Domain.Interfaces;
using Infraestructure;
using Service.Interface;
using Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PruebaAPIS
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<JsonWeatherRepository>().As<IWeatherInfo>();
            builder.RegisterType<WeatherService>().As<IWheaterService>();
            var container = builder.Build();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmCurrentTemperature(container.Resolve<IWheaterService>()));
        }
    }
}
