namespace TemperatureTask.Model
{
    class KelvinScale : IScale
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