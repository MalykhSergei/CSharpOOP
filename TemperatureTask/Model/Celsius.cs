using TemperatureTask.Common;

namespace TemperatureTask.Model
{
    class Celsius : IScale
    {
        public string Name => "Celsius";

        public double ConvertFromCelsius(double degree)
        {
            return degree;
        }

        public double ConvertToCelsius(double degree)
        {
            return degree;
        }
    }
}