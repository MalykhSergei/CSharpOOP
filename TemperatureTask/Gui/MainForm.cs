using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TemperatureTask.Model;

namespace TemperatureTask
{
    public partial class MainForm : Form
    {
        private readonly ITemperatureConverter converter;

        public MainForm(List<IScale> scales, ITemperatureConverter converter)
        {
            InitializeComponent();

            foreach (IScale scale in scales)
            {
                fromScaleComboBox.Items.Add(scale);
                toScaleComboBox.Items.Add(scale);
            }

            fromScaleComboBox.SelectedIndex = 0;
            toScaleComboBox.SelectedIndex = 0;

            this.converter = converter;
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            try
            {
                double temperature = Convert.ToDouble(entryTextField.Text);
                resultLabel.ForeColor = Color.Black;

                IScale fromScale = (IScale)fromScaleComboBox.SelectedItem;
                IScale toScale = (IScale)toScaleComboBox.SelectedItem;

                resultLabel.Text = converter.ConvertTemperature(fromScale, toScale, temperature).ToString("0.00");
            }
            catch (FormatException)
            {
                resultLabel.Text = "It must be number!";
                resultLabel.ForeColor = Color.Red;
            }
        }
    }
}

