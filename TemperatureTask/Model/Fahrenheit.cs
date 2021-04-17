using TemperatureTask.Common;

namespace TemperatureTask.Model
{
    class Fahrenheit : IScale
    {
        public string Name => "Fahrenheit";

        public double ConvertFromCelsius(double degree)
        {
            return degree * 1.8 + 32;
        }

        public double ConvertToCelsius(double degree)
        {
            return (degree - 32) * 5 / 9;
        }
    }
}
