using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemperatureTask.Common;

namespace TemperatureTask.Model
{
    class Fahrenheit : ITemperatureConverter
    {
        public double ConvertFromCelsius(double degree)
        {
            return degree * 1.8 + 32;
        }

        public double ConvertToCelsius(double degree)
        {
            return (degree - 32) * 5 / 9;
        }

        public override string ToString()
        {
            return "Fahrenheit";
        }
    }
}
