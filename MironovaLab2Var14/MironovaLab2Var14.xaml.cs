using Microsoft.Maui.Controls;

namespace MironovaLab2Var14;

public partial class MironovaLab2Var14 : ContentPage
{
    public MironovaLab2Var14()
    {
        InitializeComponent();

        inputEntry.TextChanged += OnTextChanged;
    }

    private void OnTextChanged(object sender, TextChangedEventArgs e)
    {
        string text = inputEntry.Text;

        if (!string.IsNullOrEmpty(text))
        {
            string formatted = char.ToUpper(text[0]) + text.Substring(1);
            outputLabel.Text = formatted;
        }
        else
        {
            outputLabel.Text = "";
        }
    }
}
