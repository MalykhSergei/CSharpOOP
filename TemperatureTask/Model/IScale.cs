namespace TemperatureTask.Model
{
    interface IScale
    {
        double ConvertToCelsius(double degree);

        double ConvertFromCelsius(double degree);
    }
}
