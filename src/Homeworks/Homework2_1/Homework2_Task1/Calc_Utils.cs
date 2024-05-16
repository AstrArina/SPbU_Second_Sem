namespace Stack_Calculator
{
    /// <summary>
    /// Utility class for performing arithmetic operations.
    /// </summary>
    public static class Calc_Utils
    {
        /// <summary>
        /// Checks if the given character is a valid arithmetic operation sign.
        /// </summary>
        /// <param name="value">The character to check.</param>
        /// <returns>True if the character is a valid operation sign, else false.</returns>
        public static bool IsOperationSign(this char value)
            => value == '-' || value == '+' || value == '/' || value == '*';

        /// <summary>
        /// Performs the arithmetic operation based on the given operation sign and two numbers.
        /// </summary>
        /// <param name="operation">The operation sign ('+', '-', '*', '/').</param>
        /// <param name="oneNumber">The first number for the operation.</param>
        /// <param name="twoNumber">The second number for the operation.</param>
        /// <returns>A tuple containing the result of the operation and a boolean indicating success.</returns>
        public static (float result, bool isCorrect) Perform(char operation, float oneNumber, float twoNumber)
        {
            switch (operation)
            {
                case '-':
                    return (oneNumber - twoNumber, true);
                case '+':
                    return (oneNumber + twoNumber, true);
                case '/':
                {
                    const float eps = 0.00001F;
                    return Math.Abs(0.0F - twoNumber) < eps
                        ? (0.0F, false)
                        : (oneNumber / twoNumber, true);
                }
                case '*':
                    return (oneNumber * twoNumber, true);
                default:
                    throw new ArgumentException("Invalid operation sign");
            }
        }
    }
}