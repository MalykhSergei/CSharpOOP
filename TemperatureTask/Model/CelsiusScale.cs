namespace TemperatureTask.Model
{
    class CelsiusScale : IScale
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