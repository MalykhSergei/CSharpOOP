using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TemperatureTask.Model;

namespace TemperatureTask
{
    static class App
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            List<IScale> scales = new List<IScale>
            {
                new CelsiusScale(),
                new KelvinScale(),
                new FahrenheitScale()
            };

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(scales));
        }
    }
}
