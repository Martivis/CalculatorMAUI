using NCalc;
namespace CalculatorMAUI.ViewModels;

public partial class MainViewModel : BaseViewModel
{
    [ObservableProperty]
    string display = "0";

    [RelayCommand]
    void OnDigitPress(string digit)
    {
        Console.WriteLine(digit);
        if (Display == "0")
        {
            Display = digit;
        }
        else
        {
            Display += digit;
        }
        if (Display.Contains("Error")) {
            Display = digit;
        }
    }

    [RelayCommand]
    void Clear() 
    {
        Display = "0"; 
    }


    [RelayCommand]
    void DoubleZero()
    {
        if (!string.IsNullOrEmpty(Display))
        {
            Display += "00";
        }
    }

    [RelayCommand]
    void OnOperatorPress(string op)
    {
        if (op == "=")
        {
            try
            {
                Expression e = new(Display);
                Display = e.Evaluate().ToString();
                return;
            }
            catch (Exception)
            {
                Display = "Error";
                return;
            }
        }
        Display += op;
    }
}
