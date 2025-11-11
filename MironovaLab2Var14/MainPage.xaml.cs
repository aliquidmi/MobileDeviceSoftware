using Microsoft.Maui.Controls;

namespace MironovaLab2Var14;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await MainScroll.ScrollToAsync(0, 0, true);
    }
}
