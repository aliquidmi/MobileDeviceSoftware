using System.Collections.ObjectModel;

namespace MironovaLab6Var14;

public partial class MironovaLab6Var14 : ContentPage
{
    public ObservableCollection<Language> Languages { get; set; }
        = new ObservableCollection<Language>();

    public MironovaLab6Var14()
    {
        InitializeComponent();
        LanguagesListView.ItemsSource = Languages;
    }

    private void AddLang_Clicked(object sender, EventArgs e)
    {
        if (!DateTime.TryParse(ReleaseDateEntry.Text, out DateTime date))
        {
            DisplayAlert("Помилка", "Неправильна дата", "OK");
            return;
        }

        Languages.Add(new Language(
            NameEntry.Text,
            CompanyEntry.Text,
            date
        ));

        DisplayAlert("Успіх", "Мову додано", "OK");
    }

    private void EditLang_Clicked(object sender, EventArgs e)
    {
        var lang = Languages.FirstOrDefault(l => l.Name == EditNameEntry.Text);

        if (lang == null)
        {
            DisplayAlert("Помилка", "Мову не знайдено", "OK");
            return;
        }

        lang.Name = NameEntry.Text;
        lang.Company = CompanyEntry.Text;

        if (DateTime.TryParse(ReleaseDateEntry.Text, out DateTime d))
            lang.ReleaseDate = d;

        LanguagesListView.ItemsSource = null;
        LanguagesListView.ItemsSource = Languages;

        DisplayAlert("Успіх", "Редаговано", "OK");
    }

    private void DeleteLang_Clicked(object sender, EventArgs e)
    {
        var lang = Languages.FirstOrDefault(l => l.Name == DeleteEntry.Text);

        if (lang != null)
        {
            Languages.Remove(lang);
            DisplayAlert("OK", "Мову видалено", "OK");
        }
        else
        {
            DisplayAlert("Помилка", "Не знайдено", "OK");
        }
    }
}

public class Language
{
    public string Name { get; set; }
    public string Company { get; set; }
    public DateTime ReleaseDate { get; set; }

    public string ReleaseDateFormatted => $"Реліз: {ReleaseDate:dd.MM.yyyy}";

    public Language(string name, string company, DateTime release)
    {
        Name = name;
        Company = company;
        ReleaseDate = release;
    }
}
