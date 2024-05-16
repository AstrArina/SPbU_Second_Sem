namespace Stack_Calculator
{
    /// <summary>
    /// Class for calculating results of Polish postfix expressions using a stack implementation.
    /// </summary>
    public class Polish_Postfix_Calculator
    {
        private readonly IStack stack;

        /// <summary>
        /// Initializes a new instance of the <see cref="Polish_Postfix_Calculator"/> class with the specified stack.
        /// </summary>
        /// <param name="stack">The stack implementation to use for calculations.</param>
        public Polish_Postfix_Calculator(IStack stack)
        {
            this.stack = stack ?? throw new ArgumentNullException(nameof(stack));
        }

        /// <summary>
        /// Calculates the result of the Polish postfix expression.
        /// </summary>
        /// <param name="expression">The Polish postfix expression to evaluate.</param>
        /// <returns>A tuple containing the result of the expression and a boolean indicating success.</returns>
        public (float, bool) Calc_Polish_Expression(string expression)
        {
            if (string.IsNullOrEmpty(expression))
            {
                throw new ArgumentException("Expression is null or empty");
            }

            var expressionArray = expression.Split();
            foreach (var element in expressionArray)
            {
                if (!element[0].IsOperationSign())
                {
                    if (!float.TryParse(element, out float result))
                    {
                        throw new ArgumentException("Not a number or an operation");
                    }
                    stack.Push(result);
                }
                else
                {
                    try
                    {
                        float oneElement = stack.Pop();
                        float twoElement = stack.Pop();
                        (var result, var isCorrect) = Calc_Utils.Perform(element[0], twoElement, oneElement);
                        if (!isCorrect)
                        {
                            return (0.0F, false);
                        }
                        stack.Push(result);
                    }
                    catch
                    {
                        throw new ArgumentException("Wrong expression");
                    }
                }
            }

            float endResult;
            try
            {
                endResult = stack.Pop();

                if (!stack.IsEmpty())
                {
                    throw new ArgumentException("Wrong expression");
                }

            return (endResult, true);
            }
            catch
            {
                throw new ArgumentException("Wrong expression");
            }
        }
    }
}