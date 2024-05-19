public class CalculatorLogic : ModelBase
{
    private string displayedResult = string.Empty;
    private string displayedOperation = string.Empty;

    private double currentResult;
    private string currentOperator = string.Empty;
    private string lastOperator = string.Empty;
    private double secondOperand;
    private bool isLastNumber = true;
    private bool isClean = true;

    public string DisplayedOperation
    {
        get => displayedOperation;
        set
        {
            if (displayedOperation != value)
            {
                displayedOperation = value;
                OnPropertyChanged("displayedOperation");
            }
        }
    }

    public string DisplayedResult
    {
        get => displayedResult;
        set
        {
            if (displayedResult != value)
            {
                displayedResult = value;
                OnPropertyChanged("displayedResult");
            }
        }
    }

    public void ClearResult()
    {
        DisplayedResult = string.Empty;
        DisplayedOperation = string.Empty;
        currentResult = 0;
        secondOperand = 0;
        isClean = true;
        isLastNumber = true;
        lastOperator = string.Empty;
    }

    public void ProcessNumber_Click(double number)
    {
        if (isLastNumber)
        {
            DisplayedResult += number;
            secondOperand = double.Parse(DisplayedResult);

            return;
        }

        DisplayedResult = number.ToString();
        secondOperand = number;
        isLastNumber = true;
    }

    public void ProcessOperation_Click(string enteredOperator)
    {
        if (isClean)
        {
            if (enteredOperator == "*" || enteredOperator == "/")
            {
                currentResult = 1;
            }

            isClean = false;
        }

        if (!isLastNumber)
        {
            if (currentOperator == "-" && enteredOperator == "-")
            {
                currentOperator = string.Empty;
                lastOperator = "+";
                DisplayedOperation = DisplayedResult + " " + lastOperator + " ";
                return;
            }
            else if (lastOperator == "=")
            {
                currentOperator = enteredOperator;
            }
        }
        else
        {
            currentOperator = enteredOperator;
        }

        if (currentOperator == "=")
        {
            PerformOperations(lastOperator, secondOperand);
            DisplayedResult = currentResult.ToString();
            DisplayedOperation = string.Empty;
        }
        else
        {
            if (lastOperator == string.Empty)
            {
                lastOperator = currentOperator;
                DisplayedOperation = DisplayedResult + " " + currentOperator + " ";
                currentResult = double.Parse(DisplayedResult);

                isLastNumber = false;
                return;
            }

            if (lastOperator != "=")
            {
                PerformOperations(lastOperator, secondOperand);

                DisplayedResult = currentResult.ToString();
            }
            else
            {
                currentResult = double.Parse(DisplayedResult);
            }

            DisplayedOperation = DisplayedResult + " " + currentOperator + " ";
        }

        isLastNumber = false;
        lastOperator = currentOperator;
    }

    private void PerformOperations(string operation, double operand)
    {
        switch (operation)
        {
            case "+":
                {
                    currentResult += operand;
                    break;
                }
            case "-":
                {
                    currentResult -= operand;
                    break;
                }
            case "*":
                {
                    currentResult *= operand;
                    break;
                }
            case "/":
                {
                    if (Math.Abs(operand) < 1e-6)
                    {
                        throw new DivideByZeroException("Can't divide by 0");
                    }

                    currentResult /= operand;
                    break;
                }
        }
    }
}