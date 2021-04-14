using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemperatureTask.Common;

namespace TemperatureTask.Model
{
    class Kelvin : ITemperatureConverter
    {
        public double ConvertFromCelsius(double degree)
        {
            return degree + 273.15;
        }

        public double ConvertToCelsius(double degree)
        {
            return degree - 273.15;
        }

        public override string ToString()
        {
            return "Kelvin";
        }
    }
}
