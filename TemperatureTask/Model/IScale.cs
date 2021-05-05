namespace TemperatureTask.Model
{
    public interface IScale
    {
        double ConvertToCelsius(double degree);

        double ConvertFromCelsius(double degree);
    }
}
