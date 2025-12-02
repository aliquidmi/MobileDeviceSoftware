using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MironovaLab6Var14.Models;
using Microsoft.Maui.Controls; // для Command

namespace MironovaLab6Var14.ViewModels;

public class ProgrammingLanguagesViewModel : INotifyPropertyChanged
{
    private ProgrammingLanguage? _selectedLanguage;
    private string _newName = string.Empty;
    private string _newCompany = string.Empty;
    private DateTime _newDate = DateTime.Now;

    public ObservableCollection<ProgrammingLanguage> Languages { get; } = new();

    public ProgrammingLanguage? SelectedLanguage
    {
        get => _selectedLanguage;
        set
        {
            if (_selectedLanguage == value) return;
            _selectedLanguage = value;
            OnPropertyChanged();
            // При виборі заповнюємо поля для редагування
            if (_selectedLanguage != null)
            {
                NewName = _selectedLanguage.Name;
                NewCompany = _selectedLanguage.Company;
                NewDate = _selectedLanguage.ReleaseDate;
            }
            else
            {
                // очистити поля, якщо нічого не вибрано (опційно)
                NewName = string.Empty;
                NewCompany = string.Empty;
                NewDate = DateTime.Now;
            }

            // Оновлюємо доступність команд
            ((Command)EditCommand).ChangeCanExecute();
            ((Command)DeleteCommand).ChangeCanExecute();
        }
    }

    public string NewName
    {
        get => _newName;
        set { if (_newName != value) { _newName = value; OnPropertyChanged(); ((Command)AddCommand).ChangeCanExecute(); } }
    }

    public string NewCompany
    {
        get => _newCompany;
        set { if (_newCompany != value) { _newCompany = value; OnPropertyChanged(); } }
    }

    public DateTime NewDate
    {
        get => _newDate;
        set { if (_newDate != value) { _newDate = value; OnPropertyChanged(); } }
    }

    public ICommand AddCommand { get; }
    public ICommand EditCommand { get; }
    public ICommand DeleteCommand { get; }

    public ProgrammingLanguagesViewModel()
    {
        AddCommand = new Command(AddLanguage, CanAddLanguage);
        EditCommand = new Command(EditLanguage, CanEditOrDelete);
        DeleteCommand = new Command(DeleteLanguage, CanEditOrDelete);
    }

    private bool CanAddLanguage() =>
        !string.IsNullOrWhiteSpace(NewName);

    private bool CanEditOrDelete() =>
        SelectedLanguage != null;

    void AddLanguage()
    {
        var pl = new ProgrammingLanguage
        {
            Name = NewName.Trim(),
            Company = NewCompany?.Trim() ?? string.Empty,
            ReleaseDate = NewDate
        };

        Languages.Add(pl);

        // очистити поля після додавання
        NewName = string.Empty;
        NewCompany = string.Empty;
        NewDate = DateTime.Now;
    }

    void EditLanguage()
    {
        if (SelectedLanguage == null) return;

        // Оновлюємо властивості моделі — вони піднімуть PropertyChanged і UI оновиться
        SelectedLanguage.Name = NewName;
        SelectedLanguage.Company = NewCompany;
        SelectedLanguage.ReleaseDate = NewDate;

        // опціонально — зняти виділення
        // SelectedLanguage = null;
    }

    void DeleteLanguage()
    {
        if (SelectedLanguage == null) return;

        Languages.Remove(SelectedLanguage);
        SelectedLanguage = null; // очистити вибір і поля
    }

    #region INotifyPropertyChanged
    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? name = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    #endregion
}
