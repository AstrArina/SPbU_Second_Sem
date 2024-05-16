namespace MyCalculatorTests
{
    using Stack_Calculator;

    public class MyCalculatorTests
    {
        private static IEnumerable<TestCaseData> MyCalculator()
        {
            yield return new TestCaseData(new Polish_Postfix_Calculator(new StackArray()));
            yield return new TestCaseData(new Polish_Postfix_Calculator(new StackList()));
        }

        [TestCaseSource(nameof(Polish_Postfix_Calculator))]
        public void Calculate_ValidExpression_ReturnsCorrectResult(Polish_Postfix_Calculator calculator)
        {
            var expression = "4 2 / 3 * 6 +";
            const double expectedResult = 15;
            var (result, success) = calculator.CalculatePostfixExpression(expression);

            Assert.That(success && result == expectedResult);
        }

        [TestCaseSource(nameof(Polish_Postfix_Calculator))]
        public void Calculate_DivisionByZero_ReturnsFalse(Polish_Postfix_Calculator calculator)
        {
            var expression = "4 0 /";
            var (result, success) = calculator.CalculatePostfixExpression(expression);

            Assert.That(!success);
        }

        [TestCaseSource(nameof(Polish_Postfix_Calculator))]
        public void Calculate_IncorrectExpression_ThrowsException(Polish_Postfix_Calculator calculator)
        {
            var expression = "4 2 * + 6";

            Assert.Throws<ArgumentException>(() => calculator.CalculatePostfixExpression(expression));
        }

        [TestCaseSource(nameof(Polish_Postfix_Calculator))]
        public void Calculate_EmptyExpression_ThrowsException(Polish_Postfix_Calculator calculator)
        {
            Assert.Throws<ArgumentException>(() => calculator.CalculatePostfixExpression(""));
        }

        [TestCaseSource(nameof(Polish_Postfix_Calculator))]
        public void Calculate_NullExpression_ThrowsException(Polish_Postfix_Calculator calculator)
        {
            Assert.Throws<ArgumentNullException>(() => calculator.CalculatePostfixExpression(null));
        }
    }
}
