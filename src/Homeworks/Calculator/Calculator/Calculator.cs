namespace CalculatorApp
{
    public partial class Calculator : Form
    {
        private CalculatorLogic calculator;

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
            displayWithResult.DataBindings.Add("Text", calculator, "DisplayedResult", true, DataSourceUpdateMode.OnPropertyChanged);
            displayWithOperations.DataBindings.Add("Text", calculator, "DisplayedOperations", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void Number_Click(object? sender, EventArgs e)
        {
            if (sender is Button button && button.Text != null)
            {
                calculator.ProcessNumber_Click(double.Parse(button.Text));
            }
        }

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

        private void Clear_Click(object sender, EventArgs e)
        {
            calculator.ClearResult();
        }
    }
}