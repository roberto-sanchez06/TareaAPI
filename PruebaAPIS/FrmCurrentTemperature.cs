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
                lblWindSpeed.Text = climas.wind.speed.ToString()+" m/s";
                lblTemp.Text = climas.main.temp.ToString()+" K";
                lblSunset.Text = wheaterser.convertToDateTime(climas.sys.sunset).ToShortTimeString();
                lblSunrise.Text = wheaterser.convertToDateTime(climas.sys.sunrise).ToShortTimeString();
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
                flowLayoutPanel1.Controls.Clear();
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
                frmForecast.lblDay.Text = wheaterser.convertToDateTime(forecast.daily[i].dt).DayOfWeek.ToString();
                flowLayoutPanel1.Controls.Add(frmForecast);
                frmForecast.Show();
            }
        }
    }
}
