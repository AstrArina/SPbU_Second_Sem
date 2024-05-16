namespace Stack_Calculator
{
    /// <summary>
    /// Class representing a stack based on a list.
    /// </summary>
    public class StackList : IStack
    {
        private readonly List<float> stack = new List<float>();

        /// <summary>
        /// Default constructor for creating an empty stack.
        /// </summary>
        public StackList()
        {
        }

        /// <summary>
        /// Constructor for creating a stack with specified initial objects.
        /// </summary>
        /// <param name="numbers">The initial objects to add to the stack.</param>
        public StackList(params float[] numbers)
        {
            foreach (var number in numbers)
            {
                Push(number);
            }
        }

        /// <summary>
        /// Pushes a new element onto the top of the stack.
        /// </summary>
        /// <param name="newElement">The new element to push onto the stack.</param>
        public void Push(float newElement)
        {
            stack.Insert(0, newElement);
        }

        /// <summary>
        /// Checks if the stack is empty.
        /// </summary>
        /// <returns>True if the stack is empty; otherwise false.</returns>
        public bool IsEmpty() => !stack.Any();

        /// <summary>
        /// Pops the top element from the stack and returns it.
        /// </summary>
        /// <returns>The top element of the stack.</returns>
        public float Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Wrong operation");
            }

            var temp = stack[0];
            stack.RemoveAt(0);
            return temp;
        }
    }
}