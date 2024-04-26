namespace PriorityQueue;

/// <summary>
/// Сlass for working with queue elements.
/// </summary>
public class Queue
{
    /// <summary>
    /// A queue element that stores a value,
    /// priority and link to next element.
    /// </summary>
    private class Element
    {
        public Element(object value, int priority, Element nextElement)
        {
            Value = value;
            NextElement = nextElement;
            Priority = priority;
        }

        public Element NextElement { get; set; }

        public object Value { get; set; }

        public int Priority { get; set; }
    }

    /// <summary>
    /// first element in queue.
    /// </summary>
    private Element? queueHead;

    /// <summary>
    /// Adding an element to the queue according to priority.
    /// </summary>
    /// <param name="value">Element value.</param>
    /// <param name="priority">Element priority.</param>
    public void Enqueue(object value, int priority)
    {
        if (Empty())
        {
            queueHead = new Element(value, priority, queueHead);
            return;
        }

        var current = queueHead;
        Element? previous = null;
        while (current != null && current.Priority >= priority)
        {
            previous = current;
            current = current.NextElement;
        }

        Element newElement = new Element(value, priority, current);

        if (previous == null)
        {
            queueHead = newElement;
            return;
        }

        previous.NextElement = newElement;
    }

    /// <summary>
    /// Check for empty queue.
    /// </summary>
    /// <returns>True if the queue is empty, false if there are elements.</returns>
    public bool Empty()
      => queueHead == null;

    /// <summary>
    /// Returns the value of the element with first priority
    /// </summary>
    /// <returns>element value with first priority.</returns>
    /// <exception cref="Exception">Thrown if the queue is empty.</exception>
    public object Dequeue()
    {
        if (Empty())
        {
            throw new InvalidOperationException("Queue is empty");
        }

        var value = queueHead.Value;
        queueHead = queueHead.NextElement;
        return value;
    }

    /// <summary>
    /// Checks whether the value is contained in the queue.
    /// </summary>
    /// <param name="value">Value of the first element by priority.</param>
    /// <returns>True if the queue is contained, false if not contained.</returns>
    public bool Contains(object value)
    {
        var current = queueHead;
        while (current != null)
        {
            if (current.Value == value)
            {
                return true;
            }

            current = current.NextElement;
        }

        return false;
    }

    /// <summary>
    /// Returns the value of the first element.
    /// </summary>
    /// <returns>value of the first element.</returns>
    /// <exception cref="InvalidOperationException">Thrown if the queue is empty.</exception>
    public object GetElementheadValue()
    {
        if (Empty())
        {
            throw new InvalidOperationException();
        }

        return queueHead.Value;
    }

    /// <summary>
    /// Returns the priority of the first element.
    /// </summary>
    /// <returns>priority of the first element.</returns>
    /// <exception cref="InvalidOperationException">Thrown if the queue is empty.</exception>
    public int GetElementHeadPriority()
    {
        if (Empty())
        {
            throw new InvalidOperationException();
        }

        return queueHead.Priority;
    }
}