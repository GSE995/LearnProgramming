using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatheApp.OpenWeather
{
    class Main
    {
        double _tempmin;
        public double temp_min
        {
            get { return _tempmin; }
            set { _tempmin = value - 273.5; }
        }

        double _temptmax;
        public double temp_max
        {
            get { return _temptmax; }
            set { _temptmax = value - 278; }
        }

        double _presure;
        public double presure
        {
            get
            {
                return _presure;
            }
            set
            {
                _presure = value / 1.3332239;
            }
        }
        public double humidity;

        public double Temp
        {
            get { return (_tempmin + _temptmax) / 2; }
        }
    }
}
