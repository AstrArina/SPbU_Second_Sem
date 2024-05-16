namespace Stack_Calculator.Tests
{
    using Stack_Calculator;
    using NUnit.Framework;
    using System;

    public class PolishPostfixCalculatorTests
    {
        private static IEnumerable<TestCaseData> PolishPostfixCalculator()
        {
            yield return new TestCaseData(new Polish_Postfix_Calculator(new StackArray()));
            yield return new TestCaseData(new Polish_Postfix_Calculator(new StackList()));
        }

        [TestCaseSource(nameof(PolishPostfixCalculator))]
        public void Calc_Polish_Expression_WithCorrectExpression_ReturnsCorrectResult(Polish_Postfix_Calculator calculator)
        {
            var expression = "4 2 / 3 * 6 +";
            const float expectedResult = 15;
            var (result, success) = calculator.Calc_Polish_Expression(expression);

            Assert.That(success && result == expectedResult);
        }

        [TestCaseSource(nameof(PolishPostfixCalculator))]
        public void Calc_Polish_Expression_WithDivisionByZero_ReturnsFalse(Polish_Postfix_Calculator calculator)
        {
            var expression = "4 0 /";
            var (result, success) = calculator.Calc_Polish_Expression(expression);

            Assert.That(!success);
        }

        [TestCaseSource(nameof(PolishPostfixCalculator))]
        public void Calc_Polish_Expression_WithIncorrectExpression_ThrowsException(Polish_Postfix_Calculator calculator)
        {
            var expression = "4 2 * + 6";

            Assert.Throws<ArgumentException>(() => calculator.Calc_Polish_Expression(expression));
        }

        [TestCaseSource(nameof(PolishPostfixCalculator))]
        public void Calc_Polish_Expression_WithEmptyExpression_ThrowsException(Polish_Postfix_Calculator calculator)
        {
            Assert.Throws<ArgumentException>(() => calculator.Calc_Polish_Expression(""));
        }

        [TestCaseSource(nameof(PolishPostfixCalculator))]
        public void Calc_Polish_Expression_WithNullExpression_ThrowsException(Polish_Postfix_Calculator calculator)
        {
            Assert.Throws<ArgumentException>(() => calculator.Calc_Polish_Expression(null));
        }
    }
}
