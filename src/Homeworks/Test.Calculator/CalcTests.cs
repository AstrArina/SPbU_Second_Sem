namespace Stack_Calculator.Tests
{
    using Stack_Calculator;
    using NUnit.Framework;
    using System;

    public class PolishPostfixCalculatorTests
    {
        private static IEnumerable<TestCaseData> Calculator()
        {
            yield return new TestCaseData(new PolishPostfixCalculator(new StackArray()));
            yield return new TestCaseData(new PolishPostfixCalculator(new StackList()));
        }

        [TestCaseSource(nameof(Calculator))]
        public void Calculate_WithCorrectExpression_ReturnsCorrectResult(PolishPostfixCalculator calculator)
        {
            var expression = "4 2 / 3 * 6 +";
            const float expectedResult = 15;
            var (result, success) = calculator.Calc_Polish_Expression(expression);

            Assert.That(success && result == expectedResult);
        }

        [TestCaseSource(nameof(Calculator))]
        public void Calculate_WithDivisionByZero_ReturnsFalse(PolishPostfixCalculator calculator)
        {
            var expression = "4 0 /";
            var (result, success) = calculator.Calc_Polish_Expression(expression);

            Assert.That(!success);
        }

        [TestCaseSource(nameof(Calculator))]
        public void Calculate_WithIncorrectExpression_ThrowsException(PolishPostfixCalculator calculator)
        {
            var expression = "4 2 * + 6";

            Assert.Throws<ArgumentException>(() => calculator.Calc_Polish_Expression(expression));
        }

        [TestCaseSource(nameof(Calculator))]
        public void Calculate_WithEmptyExpression_ThrowsException(PolishPostfixCalculator calculator)
        {
            Assert.Throws<ArgumentException>(() => calculator.Calc_Polish_Expression(""));
        }

        [TestCaseSource(nameof(Calculator))]
        public void Calculate_WithNullExpression_ThrowsException(PolishPostfixCalculator calculator)
        {
            Assert.Throws<ArgumentException>(() => calculator.Calc_Polish_Expression(null));
        }
    }
}
