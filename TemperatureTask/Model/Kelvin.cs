using TemperatureTask.Common;

namespace TemperatureTask.Model
{
    class Kelvin : IScale
    {
        public string Name => "Kelvin";

        public double ConvertFromCelsius(double degree)
        {
            return degree + 273.15;
        }

        public double ConvertToCelsius(double degree)
        {
            return degree - 273.15;
        }
    }
}