using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureTask.Common
{
    interface ITemperatureConverter
    {
        double ConvertToCelsius(double degree);

        double ConvertFromCelsius(double degree);
    }
}
