using Microsoft.Maui.Controls;
using System.Reflection.PortableExecutable;

namespace MironovaLab1Var10; 

public partial class MainPage : ContentPage
{
    private bool isChanged = false;

    public MainPage()
    {
        InitializeComponent();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        if (!isChanged)
        {
            header.Text = ".NET MAUI";
            header.TextColor = Colors.Blue;
            header.FontSize = 30;
        }
        else
        {
            header.Text = "Hello";
            header.TextColor = Colors.Black;
            header.FontSize = 24;
        }

        isChanged = !isChanged;
    }
}
