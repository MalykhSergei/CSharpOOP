using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemperatureTask.Common;

namespace TemperatureTask.Model
{
    class Celsius : ITemperatureConverter
    {
        public double ConvertFromCelsius(double degree)
        {
            return degree;
        }

        public double ConvertToCelsius(double degree)
        {
            return degree;
        }

        public override string ToString()
        {
            return "Celsius";
        }
    }
}
