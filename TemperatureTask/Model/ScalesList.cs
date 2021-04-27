using System.Collections.Generic;

namespace TemperatureTask.Model
{
    class ScalesList
    {
        public static List<IScale> GetScalesList()
        {
            return new List<IScale> { new CelsiusScale(), new KelvinScale(), new FahrenheitScale() };
        }
    }
}
