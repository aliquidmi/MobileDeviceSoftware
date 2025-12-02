using MironovaLab6Var14.ViewModels;

namespace MironovaLab6Var14.Views;

public partial class MironovaPage1 : ContentPage
{
    public MironovaPage1()
    {
        InitializeComponent();
        BindingContext = new ProgrammingLanguagesViewModel();
    }
}
