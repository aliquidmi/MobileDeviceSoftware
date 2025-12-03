using System.ComponentModel;
using System.Windows.Input;

namespace MironovaRGZVar14.ViewModels;

public class CalculatorViewModel : INotifyPropertyChanged
{
    private string _display = "0";
    private double _first;
    private string _operation;

    public string Display
    {
        get => _display;
        set { _display = value; OnPropertyChanged(nameof(Display)); }
    }

    public ICommand AddDigitCommand { get; }
    public ICommand ClearCommand { get; }
    public ICommand RemoveLastCommand { get; }
    public ICommand OperationCommand { get; }
    public ICommand ResultCommand { get; }

    public CalculatorViewModel()
    {
        AddDigitCommand = new Command<string>(AddDigit);
        ClearCommand = new Command(() => Display = "0");
        RemoveLastCommand = new Command(RemoveLast);
        OperationCommand = new Command<string>(SetOperation);
        ResultCommand = new Command(CalcResult);
    }

    private void AddDigit(string d)
    {
        if (Display == "0") Display = d;
        else Display += d;
    }

    private void RemoveLast()
    {
        if (Display.Length > 1) Display = Display[..^1];
        else Display = "0";
    }

    private void SetOperation(string op)
    {
        _first = double.Parse(Display);
        _operation = op;
        Display = "0";
    }

    private void CalcResult()
    {
        double second = double.Parse(Display);
        double result = _first;

        switch (_operation)
        {
            case "+": result += second; break;
            case "-": result -= second; break;
            case "*": result *= second; break;
            case "/": result /= second; break;
            case "√": result = Math.Sqrt(_first); break;
        }

        Display = result.ToString();
    }

    public event PropertyChangedEventHandler PropertyChanged;
    void OnPropertyChanged(string name) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
