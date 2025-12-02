using System.Collections.ObjectModel;

namespace MironovaLab5Var14;

public partial class MironovaLab5Var14 : ContentPage
{
    public ObservableCollection<Teacher> Teachers { get; set; }
        = new ObservableCollection<Teacher>();

    public MironovaLab5Var14()
    {
        InitializeComponent();
        TeachersListView.ItemsSource = Teachers;
    }

    private void AddTeacher_Clicked(object sender, EventArgs e)
    {
        try
        {
            string ln = LastNameEntry.Text;
            string fn = FirstNameEntry.Text;
            string mn = MiddleNameEntry.Text;
            string title = AcademicTitleEntry.Text;

            if (!DateTime.TryParse(BirthDateEntry.Text, out DateTime bd))
            {
                DisplayAlert("Помилка", "Некоректна дата.", "OK");
                return;
            }

            Teacher t = new Teacher(ln, fn, mn, bd, title);
            Teachers.Add(t);

            DisplayAlert("Успіх", "Викладача додано.", "OK");
        }
        catch (Exception ex)
        {
            DisplayAlert("Помилка", ex.Message, "OK");
        }
    }

    private void DeleteTeacher_Clicked(object sender, EventArgs e)
    {
        string last = DeleteEntry.Text;

        var t = Teachers.FirstOrDefault(x => x.LastName == last);

        if (t != null)
        {
            Teachers.Remove(t);
            DisplayAlert("Успіх", "Викладача видалено.", "OK");
        }
        else
        {
            DisplayAlert("Помилка", "Такого викладача нема.", "OK");
        }
    }
}

public class Teacher
{
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public DateTime BirthDate { get; set; }
    public string AcademicTitle { get; set; }

    public int Age
    {
        get
        {
            int age = DateTime.Now.Year - BirthDate.Year;
            if (BirthDate > DateTime.Now.AddYears(-age)) age--;
            return age;
        }
    }

    public string FullName => $"{LastName} {FirstName} {MiddleName}";
    public string BirthDateFormatted => $"Дата народження: {BirthDate:dd.MM.yyyy}";
    public string AgeFormatted => $"Вік: {Age}";

    public Teacher(string ln, string fn, string mn, DateTime birth, string title)
    {
        if (CalculateAge(birth) < 17 || CalculateAge(birth) > 80)
            throw new Exception("Вік викладача має бути 17–80 років!");

        LastName = ln;
        FirstName = fn;
        MiddleName = mn;
        BirthDate = birth;
        AcademicTitle = title;
    }

    private int CalculateAge(DateTime d)
    {
        int a = DateTime.Now.Year - d.Year;
        if (d > DateTime.Now.AddYears(-a)) a--;
        return a;
    }
}
