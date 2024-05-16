namespace UniqueList;

using System.Collections;

using System.Collections.Generic;

public class MyList<T> : IEnumerable<T>
{
    private protected Node? head;

    public int Size { get; private set; }

    public T this[int index]
    {
        get { return GetValue(index); }
        set { Change(index, value); }
    }

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

    public virtual void Change(int index, T newElement)
    {
        if (index < 0 || index > this.Size)
        {
            throw new ArgumentOutOfRangeException("Index out of range");
        }

        GetNode(index).Value = newElement;
    }

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