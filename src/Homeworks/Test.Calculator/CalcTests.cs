namespace MyCalculatorTests
{
    using StackCalculator;

    public class MyCalculatorTests
    {
        private static IEnumerable<TestCaseData> MyCalculator()
        {
            yield return new TestCaseData(new MyCalculator(new MyStackArray()));
            yield return new TestCaseData(new MyCalculator(new MyStackList()));
        }

        [TestCaseSource(nameof(MyCalculator))]
        public void Calculate_ValidExpression_ReturnsCorrectResult(MyCalculator calculator)
        {
            var expression = "4 2 / 3 * 6 +";
            const double expectedResult = 15;
            var (result, success) = calculator.CalculatePostfixExpression(expression);

            Assert.That(success && result == expectedResult);
        }

        [TestCaseSource(nameof(MyCalculator))]
        public void Calculate_DivisionByZero_ReturnsFalse(MyCalculator calculator)
        {
            var expression = "4 0 /";
            var (result, success) = calculator.CalculatePostfixExpression(expression);

            Assert.That(!success);
        }

        [TestCaseSource(nameof(MyCalculator))]
        public void Calculate_IncorrectExpression_ThrowsException(MyCalculator calculator)
        {
            var expression = "4 2 * + 6";

            Assert.Throws<ArgumentException>(() => calculator.CalculatePostfixExpression(expression));
        }

        [TestCaseSource(nameof(MyCalculator))]
        public void Calculate_EmptyExpression_ThrowsException(MyCalculator calculator)
        {
            Assert.Throws<ArgumentException>(() => calculator.CalculatePostfixExpression(""));
        }

        [TestCaseSource(nameof(MyCalculator))]
        public void Calculate_NullExpression_ThrowsException(MyCalculator calculator)
        {
            Assert.Throws<ArgumentNullException>(() => calculator.CalculatePostfixExpression(null));
        }
    }
}
