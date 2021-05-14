namespace TemperatureTask.Model
{
    public interface ITemperatureConverter
    {
        double ConvertTemperature(IScale fromScale, IScale toScale, double temperature);
    }
}
