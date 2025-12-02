using Microsoft.Maui.Controls;

namespace MironovaLab4Var14
{
    public partial class MironovaLab4Var14 : ContentPage
    {
        public ImageSource WebImg { get; set; }
        public ImageSource FileImg { get; set; }
        public ImageSource ResourceImg { get; set; }

        public MironovaLab4Var14()
        {
            InitializeComponent();  

            string dots = new string('.', 30);
            StudentLabel.Text = $"{dots} Міронова Алла | Лабораторна робота №4 | Варіант 14";

            WebImg = ImageSource.FromUri(new Uri("https://picsum.photos/id/237/200/300"));

            FileImg = ImageSource.FromFile("localphoto.jpg");

            ResourceImg = ImageSource.FromFile("embedded.png");

            BindingContext = this;
        }
    }
}
