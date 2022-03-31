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
           var climas =  wheaterser.GetWeather(textBox1.Text); 
            lblWindSpeed.Text = climas.wind.speed.ToString();
            lblTemp.Text = climas.main.temp.ToString();
            lblSunset.Text = climas.sys.sunset.ToString();
            lblSunrise.Text = climas.sys.sunrise.ToString();
            lblPressure.Text = climas.main.pressure.ToString();
            lblMinTemp.Text = climas.main.temp_min.ToString(); 
            lblMaxTemp.Text = climas.main.temp_max.ToString();
            lblLon.Text = climas.coord.lon.ToString();
            lblLat.Text = climas.coord.lat.ToString();
            lblHuminity.Text = climas.main.humidity.ToString();
            lblCountry.Text = climas.sys.country;
        }

        private void FrmCurrentTemperature_Load(object sender, EventArgs e)
        {
            lblWindSpeed.Text = string.Empty;
            lblTemp.Text = string.Empty;
            lblSunset.Text = string.Empty;
            lblSunrise.Text = string.Empty;
            lblPressure.Text = string.Empty;
            lblMinTemp.Text = string.Empty;
            lblMaxTemp.Text = string.Empty;
            lblLon.Text = string.Empty;
            lblLat.Text = string.Empty;
            lblHuminity.Text = string.Empty;
            lblCountry.Text = string.Empty;
        }
    }
}
