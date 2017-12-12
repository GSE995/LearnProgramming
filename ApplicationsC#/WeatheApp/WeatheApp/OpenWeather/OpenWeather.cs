using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace WeatheApp.OpenWeather
{
    class OpenWeather
    {
        public Coords coord;

        public Weather[] weather;

        [JsonProperty ("base")]
        public string Base;

        public Main main;

        public double visibility;

        public Wind wind;

        public Clouds clouds;

        public double dt;

        public Sys sys;

        public int id;
                        
        public string name;

        public double cod;
    }
}
