namespace TemperatureTask.Model
{
    class FahrenheitScale : IScale
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
