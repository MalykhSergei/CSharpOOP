using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TemperatureTask.Model;
using TemperatureTask.Common;

namespace TemperatureTask
{
    public partial class MainForm : Form
    {
        private IScale fromScale;
        private IScale toScale;

        private readonly List<IScale> scales = new List<IScale>
        {
            new Celsius(),
            new Kelvin(),
            new Fahrenheit()
        };

        public MainForm()
        {
            InitializeComponent();

            foreach (var scale in scales)
            {
                fromScaleComboBox.Items.Add(scale.Name);
                toScaleComboBox.Items.Add(scale.Name);
            }

            fromScaleComboBox.SelectedIndex = 0;
            toScaleComboBox.SelectedIndex = 0;
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            try
            {
                double temperature = Convert.ToDouble(entryTextField.Text);
                resultLabel.ForeColor = Color.Black;

                foreach (var currentScale in scales)
                {
                    if (fromScaleComboBox.Text.Equals(currentScale.Name))
                    {
                        fromScale = currentScale;
                    }

                    if (toScaleComboBox.Text.Equals(currentScale.Name))
                    {
                        toScale = currentScale;
                    }
                }

                resultLabel.Text = TemperatureConverter.ConvertTemperature(fromScale, toScale, temperature).ToString("0.00");
            }
            catch (FormatException)
            {
                resultLabel.Text = "It must be number!";
                resultLabel.ForeColor = Color.Red;
            }
        }
    }
}

