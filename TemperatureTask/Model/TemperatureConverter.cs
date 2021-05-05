namespace TemperatureTask.Model
{
    class TemperatureConverter
    {
        public double ConvertTemperature(IScale fromScale, IScale toScale, double temperature)
        {
            return toScale.ConvertFromCelsius(fromScale.ConvertToCelsius(temperature));
        }
    }
}
