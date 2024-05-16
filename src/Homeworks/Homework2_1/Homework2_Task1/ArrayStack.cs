namespace Stack_Calculator
{
    /// <summary>
    /// Class representing a stack based on an array.
    /// </summary>
    public class StackArray : IStack
    {
        private int firstElementIndex = -1; 
        private int actualArraySize = 2;
        private float[] stack;

        /// <summary>
        /// Constructor without parameters.
        /// Creates an empty stack with an initial array size.
        /// </summary>
        public StackArray()
        {
            this.stack = new float[this.actualArraySize];
        }

        /// <summary>
        /// Constructor with parameters.
        /// Creates a stack with the given elements.
        /// </summary>
        /// <param name="numbers">The elements to be added to the stack.</param>
        public StackArray(params float[] numbers)
        {
            stack = new float[actualArraySize];
            foreach (var number in numbers)
            {
                Push(number);
                Console.WriteLine(number);
            }
        }

        /// <summary>
        /// Increase the size of the stack array.
        /// </summary>
        private void NewSizeStack()
        {
            actualArraySize *= 2;
            var temporaryArray = new float[actualArraySize];
            stack.CopyTo(temporaryArray, 0);
            stack = temporaryArray;
        }

        /// <summary>
        /// Add an element to the stack.
        /// </summary>
        /// <param name="newElement">The element to be added to the stack.</param>
        public void Push(float newElement)
        {
            firstElementIndex++;
            if (firstElementIndex == actualArraySize)
            {
                NewSizeStack();
            }
            stack[firstElementIndex] = newElement;
        }

        /// <summary>
        /// Check if the stack is empty.
        /// </summary>
        /// <returns>True if the stack is empty; otherwise false.</returns>
        public bool IsEmpty() => firstElementIndex == -1;

        /// <summary>
        /// Remove the top element from the stack and return it.
        /// </summary>
        /// <returns>The top element of the stack.</returns>
        public float Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Wrong operation");
            }
            firstElementIndex--;
            return stack[firstElementIndex + 1];
        }
    }
}