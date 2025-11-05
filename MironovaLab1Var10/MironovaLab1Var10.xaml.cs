using Microsoft.Maui.Controls;

namespace MironovaLab1Var10;

public partial class MironovaLab1Var10 : ContentPage
{
    private bool isChanged = false;
    private int armstrongStep = 1;

    public MironovaLab1Var10()
    {
        InitializeComponent();
    }

    private void Button1_Clicked(object sender, EventArgs e)
    {
        if (!isChanged)
        {
            label2.BackgroundColor = Colors.LightBlue;
            label2.TextColor = Colors.Yellow;
            button1.Text = "Çì³íåíî";
        }
        else
        {
            label2.BackgroundColor = Colors.Yellow;
            label2.TextColor = Colors.LightBlue;
            button1.Text = "Çì³íèòè";
        }
        isChanged = !isChanged;
    }

    private void Button2_Clicked(object sender, EventArgs e)
    {
        int armstrongNumber = GetNthArmstrong(armstrongStep);
        button2.Text = $"×èñëî Àìñòğîíãà = {armstrongNumber}";
        armstrongStep++;
    }

    private int GetNthArmstrong(int n)
    {
        int count = 0;
        int num = 0;

        while (true)
        {
            if (IsArmstrong(num))
            {
                count++;
                if (count == n)
                    return num;
            }
            num++;
        }
    }

    private bool IsArmstrong(int number)
    {
        if (number == 0)
            return true;

        int sum = 0;
        int temp = number;
        int digits = number.ToString().Length;

        while (temp > 0)
        {
            int d = temp % 10;
            sum += (int)Math.Pow(d, digits);
            temp /= 10;
        }

        return sum == number;
    }
}
