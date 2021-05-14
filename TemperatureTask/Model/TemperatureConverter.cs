namespace TemperatureTask.Model
{
    public class TemperatureConverter : ITemperatureConverter
    {
        public double ConvertTemperature(IScale fromScale, IScale toScale, double temperature)
        {
            return toScale.ConvertFromCelsius(fromScale.ConvertToCelsius(temperature));
        }
    }
}
