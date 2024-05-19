namespace CalculatorApp;

/// <summary>
/// Provides constants for displayed results and operations.
/// </summary>
public static class Constants
{
    public const string DisplayedResult = "DisplayedResult";
    public const string DisplayedOperations = "DisplayedOperations";
}

/// <summary>
/// Represents the calculator form.
/// </summary>
public partial class Calculator : Form
{
    private CalculatorLogic calculator;

    /// <summary>
    /// Initializes a new instance of the <see cref="Calculator"/> class.
    /// </summary>
    public Calculator()
    {
        InitializeComponent();
        foreach (Control control in tableLayoutWithButtons.Controls)
        {
            if (control is Button && control.Name.StartsWith("Number"))
            {
                control.Click += Number_Click;
            }
        }

        foreach (Control control in tableLayoutWithButtons.Controls)
        {
            if (control is Button && control.Name.EndsWith("Sign"))
            {
                control.Click += Operation_Click;
            }
        }

        calculator = new CalculatorLogic();
        displayWithResult.DataBindings.Add("Text", calculator, Constants.DisplayedResult, true, DataSourceUpdateMode.OnPropertyChanged);
        displayWithOperations.DataBindings.Add("Text", calculator, Constants.DisplayedOperations, true, DataSourceUpdateMode.OnPropertyChanged);
    }

    /// <summary>
    /// Handles the click event for number buttons.
    /// </summary>
    private void Number_Click(object? sender, EventArgs e)
    {
        if (sender is Button button && button.Text != null)
        {
            calculator.ProcessNumber_Click(double.Parse(button.Text));
        }
    }

    /// <summary>
    /// Handles the click event for operation buttons.
    /// </summary>
    private void Operation_Click(object? sender, EventArgs e)
    {
        if (sender is Button button && button.Text != null)
        {
            try
            {
                calculator.ProcessOperation_Click(button.Text);
            }
            catch (FormatException)
            {
                displayWithResult.Text = "Error";
            }
            catch (DivideByZeroException)
            {
                displayWithResult.Text = "Can't divide by 0";
            }
        }
    }

    /// <summary>
    /// Handles the click event for the clear button.
    /// </summary>
    private void Clear_Click(object sender, EventArgs e)
    {
        calculator.ClearResult();
    }
}