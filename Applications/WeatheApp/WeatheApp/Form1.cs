using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net;
using System.IO;



namespace WeatheApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void Loader(string arg)
        {
            city.Text = arg;

            WebRequest request = WebRequest.Create($"http://api.openweathermap.org/data/2.5/weather?q={arg}&APPID=1a2762f5f6be54e3889c29287ed18a46");

            request.Method = "POST";

            request.ContentType = "aplication/x-www-urlencoded";

            WebResponse response = await request.GetResponseAsync();

            string answer = String.Empty;

            using (Stream s = response.GetResponseStream())
            {
                using (StreamReader read = new StreamReader(s))
                {
                    answer = await read.ReadToEndAsync();
                }
            }

            response.Close();

            diaplayWeatherData.Text = answer;

            OpenWeather.OpenWeather ow = JsonConvert.DeserializeObject<OpenWeather.OpenWeather>(answer);

            panel1.BackgroundImage = ow.weather[0].Icon;
            label3.Text = "Средняя температура (С):" + ow.main.Temp.ToString("0.##");
            label6.Text = "Cкорость (м/с):" + ow.wind.speed.ToString();
            label7.Text = "Направление: " + ow.wind.deg.ToString();
            label4.Text = "Влажность: " + ow.main.humidity.ToString();
            label5.Text = "Давление: " + ((int)ow.main.presure).ToString();
            label1.Text = ow.weather[0].main;
            label2.Text = ow.weather[0].description;
        }

       

        private async void Form1_Load(object sender, EventArgs e)
        {
            Loader("Ivanovo");
        }

        private async void diaplayWeatherData_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Loader(inputCity.Text);
        }
    }
}
