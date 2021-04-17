namespace TemperatureTask.Common
{
    class TemperatureConverter
    {
        public string Name { get; }

        public static double ConvertTemperature(IScale scale1, IScale scale2, double temperature)
        {
            return scale2.ConvertFromCelsius(scale1.ConvertToCelsius(temperature));
        }
    }
}
