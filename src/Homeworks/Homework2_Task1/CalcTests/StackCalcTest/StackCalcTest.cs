namespace Stack_Calculator_Tests;
using Stack_Calculator;
public class Stack_Calculator_Tests {
    private static IEnumerable<TestCaseData> Polish_Postfix_Calculator() {
        yield return new TestCaseData(new Calculator(new StackArray()));
        yield return new TestCaseData(new Calculator(new StackList()));
    }
    [TestCaseSource(nameof(Stack_Calculator))]
    public void Calc_Polish_Expression_CorrectExpression_CorrectResult(Calculator calculator) {
    var expression = "7.3 4 9.14 + / 8.11 *";
    const double correctResult = 4.5055556;
    var (result, correct) = calculator.Calc_Polish_Expression(expression);
    Assert.That(correct && Math.Abs(result - correctResult) < 1e-10);
    }
    [TestCaseSourse(nameof(Stack_Calculator))]
    public void Calc_Polish_Expression_DivisionByZero_CorrectResult(Calculator calculator) {
    var expression = "7 0 /";
    var (result, correct) = calculator.Calc_Polish_Expression(expression);
    Assert.That(!correct);
    }
    [TestCaseSource(nameof(Stack_Calculator))]
    public void Calc_Polish_Expression_InCorrectExpression_ThrowResult(Calculator calculator) {
        var expression = "5 7.8 3 - * 5.1";
        Assert.Throws<ArgumentException>(() => calculator.Calc_Polish_Expression(expression));
    }
    [TestCaseSource(nameof(Stack_Calculator))]
    public void Calc_Polish_Expression_EmptyExpression_ThrowResult(Calculator calculator) {
        Assert.Throws<ArgumentException>(() => calculator.Calc_Polish_Expression(string.Empty));
    }
    [TestCaseSource(nameof(Stack_Calculator))]
    public void Calc_Polish_Expression_NullExpression_ThrowResult(Calculator calculator) {
        Assert.Throws<ArgumentException>(() => calculator.Calc_Polish_Expression(null));
    }
}