namespace Stack_Calculator
{
    /// <summary>
    /// Interface representing a stack data structure.
    /// </summary>
    public interface IStack
    {
        /// <summary>
        /// Pushes a new element onto the stack.
        /// </summary>
        /// <param name="newElement">The new element to push onto the stack.</param>
        void Push(float newElement);

        /// <summary>
        /// Pops the top element from the stack and returns it.
        /// </summary>
        /// <returns>The top element of the stack.</returns>
        float Pop();

        /// <summary>
        /// Checks if the stack is empty.
        /// </summary>
        /// <returns>True if the stack is empty; otherwise false.</returns>
        bool IsEmpty();
    }
}