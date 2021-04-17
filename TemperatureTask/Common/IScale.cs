namespace TemperatureTask.Common
{
    interface IScale
    {
        string Name { get; }

        double ConvertToCelsius(double degree);

        double ConvertFromCelsius(double degree);
    }
}
