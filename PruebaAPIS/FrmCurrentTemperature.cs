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
                pbWeather.ImageLocation = wheaterser.GetImageLocation(climas);
                lblCondition.Text = climas.weather[0].main.ToString();
                lblDetails.Text = climas.weather[0].description.ToString();
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
    }
}
