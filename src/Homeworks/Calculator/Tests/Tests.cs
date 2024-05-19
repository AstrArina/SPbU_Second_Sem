public class CalculatorLogicTests 
{
    private CalculatorLogic calculator;

    [SetUp]
    public void Setup()
    {
        calculator = new CalculatorLogic();
    }

    [Test]
    public void ProcessNumber_Click_UpdatesDisplayedResult()
    {
        calculator.ProcessNumber_Click(5);

        var expectedResult = "5";
        Assert.That(calculator.DisplayedResult, Is.EqualTo(expectedResult));
    }

    [TestCase(5, "+", 3, ExpectedResult = "8")]
    [TestCase(5, "-", 3, ExpectedResult = "2")]
    [TestCase(5, "*", 3, ExpectedResult = "15")]
    [TestCase(6, "/", 3, ExpectedResult = "2")]
    public string ProcessOperation_Click_WithOneOperation_ShouldReturnExpectedResult(double firstOperand, string operation, double secondOperand)
    {
        calculator.ProcessNumber_Click(firstOperand);
        calculator.ProcessOperation_Click(operation);
        calculator.ProcessNumber_Click(secondOperand);
        calculator.ProcessOperation_Click("=");

        return calculator.DisplayedResult;
    }

    [TestCase(1, "+", 2, "*", 3, ExpectedResult = "9")]
    [TestCase(10, "-", 2, "*", 3, ExpectedResult = "24")]
    [TestCase(3, "*", 2, "+", 4, ExpectedResult = "10")]
    public string ProcessOperation_Click_WithSeveralOperations_ShouldReturnExpectedResult(double firstOperand, string firstOperation, double secondOperand, string secondOperation, double thirdOperand)
    {
        calculator.ProcessNumber_Click(firstOperand);
        calculator.ProcessOperation_Click(firstOperation);
        calculator.ProcessNumber_Click(secondOperand);
        calculator.ProcessOperation_Click(secondOperation);
        calculator.ProcessNumber_Click(thirdOperand);

        calculator.ProcessOperation_Click("=");

        return calculator.DisplayedResult;
    }

    [Test]
    public void ProcessOperation_Click_DivideByZero_SouldThrowDivideByZeroException()
    {
        calculator.ProcessNumber_Click(6);
        calculator.ProcessOperation_Click("/");
        calculator.ProcessNumber_Click(0);

        Assert.Throws<DivideByZeroException>(() => calculator.ProcessOperation_Click("="));
    }

    [Test]
    public void ClearResult_ResetsCalculator()
    {
        calculator.ProcessNumber_Click(5);
        calculator.ProcessOperation_Click("+");
        calculator.ProcessNumber_Click(3);

        calculator.ClearResult();

        Assert.That(calculator.DisplayedResult, Is.EqualTo(string.Empty));
        Assert.That(calculator.DisplayedOperation, Is.EqualTo(string.Empty));
    }
}