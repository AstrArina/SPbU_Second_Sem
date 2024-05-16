namespace UniqueList;

using System.Collections;

using System.Collections.Generic;

/// <summary>
/// Generic linked list implementation.
/// </summary>
public class MyList<T> : IEnumerable<T>
{
    private protected Node? head;

    /// <summary>
    /// Gets the number of elements in the list.
    /// </summary>
    public int Size { get; private set; }

    /// <summary>
    /// Gets or sets the element at the specified index.
    /// </summary>
    /// <param name="index">The zero-based index of the element to get or set.</param>
    /// <returns>The element at the specified index.</returns>
    public T this[int index]
    {
        get { return GetValue(index); }
        set { Change(index, value); }
    }

    /// <summary>
    /// Adds a new element to the end of the list.
    /// </summary>
    /// <param name="element">The element to add to the list.</param>
    public virtual void Add(T element)
    {
        var newNode = new Node(element);

        if (head == null)
        {
            head = newNode;
        }
        else
        {
            var currentNode = head;

            while (currentNode.Next != null)
            {
                currentNode = currentNode.Next;
            }

            currentNode.Next = newNode;
        }

        ++Size;
    }

    /// <summary>
    /// Inserts a new element at the specified index in the list.
    /// </summary>
    /// <param name="index">The zero-based index at which the element should be inserted.</param>
    /// <param name="element">The element to insert in the list.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the index is out of range.</exception>
    public virtual void Insert(int index, T element)
    {
        if (index < 0 || index > Size)
        {
            throw new ArgumentOutOfRangeException("Index out of range");
        }

        if (index == 0)
        {
            var next = head;
            head = new Node(element);
            head.Next = next;
        }
        else
        {
            var newNode = new Node(element);

            var previousNode = GetNode(index - 1);

            newNode.Next = previousNode.Next;
            previousNode.Next = newNode;
        }

        ++Size;
    }

    /// <summary>
    /// Removes the element at the specified index from the list.
    /// </summary>
    /// <param name="index">The zero-based index of the element to be removed.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the index is out of range.</exception>
    /// <exception cref="InvalidRemoveOperationException">Thrown when trying to remove an element from an empty list.</exception>
    public void Remove(int index)
    {
        if (index < 0 || index > this.Size)
        {
            throw new ArgumentOutOfRangeException("Index out of range", nameof(index));
        }

        if (Size == 0)
        {
            throw new InvalidRemoveOperationException("Can't remove element from empty list");
        }

        if (index == 0)
        {
            head = head!.Next;
        }
        else
        {
            var previousNode = GetNode(index - 1);
            previousNode.Next = previousNode.Next!.Next;
        }

        --Size;
    }

    /// <summary>
    /// Replaces the element at the specified index with a new element.
    /// </summary>
    public virtual void Change(int index, T newElement)
    {
        if (index < 0 || index > this.Size)
        {
            throw new ArgumentOutOfRangeException("Index out of range");
        }

        GetNode(index).Value = newElement;
    }

    /// <summary>
    /// Retrieves the element at the specified index.
    /// </summary>
    public T GetValue(int index)
        => GetNode(index).Value;

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        Node? currentNode = head;
        while (currentNode != null)
        {
            yield return currentNode.Value;
            currentNode = currentNode.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable<T>)this).GetEnumerator();
    }

    private Node GetNode(int index)
    {
        var currentNode = head;

        for (var i = 0; i < index; i++)
        {
            currentNode = currentNode!.Next;
        }

        return currentNode!;
    }

    private protected class Node
    {
        public Node(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }

        public Node? Next { get; set; }
    }
}