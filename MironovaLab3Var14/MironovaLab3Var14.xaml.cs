using System;
using Microsoft.Maui.Controls;

namespace MironovaLab3Var14
{
    public partial class MironovaLab3Var14 : ContentPage
    {
        public MironovaLab3Var14()
        {
            InitializeComponent();
        }

        // Контроль введення тексту
        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (double.TryParse(e.NewTextValue, out double value))
            {
                if (value < 0)
                {
                    inputEntry.BackgroundColor = Colors.LightPink;
                    convertButton.IsEnabled = false;
                }
                else
                {
                    inputEntry.BackgroundColor = Colors.White;
                    convertButton.IsEnabled = true;
                }
            }
            else
            {
                inputEntry.BackgroundColor = Colors.LightGray;
                convertButton.IsEnabled = false;
            }
        }

        // Подія натискання кнопки
        private void OnConvertClicked(object sender, EventArgs e)
        {
            if (!double.TryParse(inputEntry.Text, out double inputValue) || inputValue < 0)
                return;

            string fromUnit = GetCheckedValue(fromGroup);
            string toUnit = GetCheckedValue(toGroup);

            double valueInLiters = ConvertToLiters(inputValue, fromUnit);
            double result = ConvertFromLiters(valueInLiters, toUnit);

            resultEntry.Text = $"{result:F4}";
        }

        // Отримати вибрану одиницю
        private string GetCheckedValue(Layout layout)
        {
            foreach (var view in layout.Children)
            {
                if (view is RadioButton rb && rb.IsChecked)
                    return rb.Value.ToString();
            }
            return "liter";
        }

        // Переведення в літри
        private double ConvertToLiters(double value, string unit)
        {
            return unit switch
            {
                "liter" => value,
                "ml" => value / 1000,
                "m3" => value * 1000,
                "gallon" => value * 3.785,
                "pint" => value * 0.473,
                _ => value
            };
        }

        // Переведення з літрів
        private double ConvertFromLiters(double value, string unit)
        {
            return unit switch
            {
                "liter" => value,
                "ml" => value * 1000,
                "m3" => value / 1000,
                "gallon" => value / 3.785,
                "pint" => value / 0.473,
                _ => value
            };
        }
    }
}
