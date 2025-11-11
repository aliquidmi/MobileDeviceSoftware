namespace MironovaLab3Var14
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new MironovaLab3Var14());
        }
    }
}
