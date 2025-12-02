using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MironovaLab6Var14.Models;

public class ProgrammingLanguage : INotifyPropertyChanged
{
    private string _name;
    private string _company;
    private DateTime _releaseDate;

    public string Name
    {
        get => _name;
        set { if (_name != value) { _name = value; OnPropertyChanged(); } }
    }

    public string Company
    {
        get => _company;
        set { if (_company != value) { _company = value; OnPropertyChanged(); } }
    }

    public DateTime ReleaseDate
    {
        get => _releaseDate;
        set { if (_releaseDate != value) { _releaseDate = value; OnPropertyChanged(); } }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? propName = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
}
