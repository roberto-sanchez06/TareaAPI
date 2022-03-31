using Domain.Entities;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PruebaAPIS
{
    public partial class FrmCurrentTemperature : Form
    {
        private IWheaterService wheaterser;
        public FrmCurrentTemperature(IWheaterService wheaterser)
        {
            this.wheaterser = wheaterser;
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                var climas = wheaterser.GetWeather(textBox1.Text);
                lblWindSpeed.Text = climas.wind.speed.ToString();
                lblTemp.Text = climas.main.temp.ToString()+" K";
                lblSunset.Text = convertToDateTime(climas.sys.sunset).ToShortTimeString();
                lblSunrise.Text = convertToDateTime(climas.sys.sunrise).ToShortTimeString();
                lblPressure.Text = climas.main.pressure.ToString();
                lblMinTemp.Text = climas.main.temp_min.ToString()+" K";
                lblMaxTemp.Text = climas.main.temp_max.ToString()+" K";
                lblLon.Text = climas.coord.lon.ToString();
                lblLat.Text = climas.coord.lat.ToString();
                lblHuminity.Text = climas.main.humidity.ToString();
                lblCountry.Text = climas.sys.country;
                pbWeather.ImageLocation = wheaterser.GetImageLocation(climas.weather[0]);
                lblCondition.Text = climas.weather[0].main.ToString();
                lblDetails.Text = climas.weather[0].description.ToString();

                ShowForecast();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);;
                
            }
        }

        private void FrmCurrentTemperature_Load(object sender, EventArgs e)
        {
        }
        private DateTime convertToDateTime(long milisegundos)
        {
            DateTime day = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).ToLocalTime();
            day = day.AddSeconds(milisegundos).ToLocalTime();
            return day;
        }
        private void ShowForecast()
        {
            ForecastInfo forecast = wheaterser.GetWeatherForecast();
            FrmForecast frmForecast;
            for(int i=0; i<8; i++)
            {
                frmForecast = new FrmForecast();
                frmForecast.TopLevel = false;
                frmForecast.pictureBox1.ImageLocation = wheaterser.GetImageLocation(forecast.daily[i].weather[0]);
                frmForecast.lblDescription.Text = forecast.daily[i].weather[0].description;
                frmForecast.lblWeather.Text = forecast.daily[i].weather[0].main;
                frmForecast.lblDay.Text = convertToDateTime(forecast.daily[i].dt).DayOfWeek.ToString();
                flowLayoutPanel1.Controls.Add(frmForecast);
                frmForecast.Show();
            }
        }
    }
}
