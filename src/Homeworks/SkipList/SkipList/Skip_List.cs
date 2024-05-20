namespace Skip_List;

using System.Collections;

/// <summary>
/// Represents a skip list, which is a probabilistic data structure that utilizes multiple levels of linked lists to efficiently perform operations such as insertion, deletion, and searching.
/// </summary>
/// <typeparam name="T">The type of elements stored in the skip list.</typeparam>
public class SkipList<T> : IList<T>
    where T : IComparable<T>
{
    private const int MaxLevel = 16;

    private readonly SkipListElement nil = new (default, default, default);

    private readonly Random random = new ();

    private SkipListElement downHead;

    private int version;

    private SkipListElement head;

    /// <summary>
    /// Initializes a new instance of the <see cref="SkipList{T}"/> class.
    /// </summary>
    public SkipList()
    {
        head = new (default, nil, default);
        var current = head;
        for (var i = 0; i < MaxLevel - 1; ++i)
        {
            current.Down = new SkipListElement(default, nil, default);
            current = current.Down;
        }

        downHead = current;
    }

    /// <summary>
    /// Gets the number of elements in the skip list.
    /// </summary>
    public int Count { get; private set; }

    /// <summary>
    /// Gets a value indicating whether the skip list is read-only.
    /// </summary>
    public bool IsReadOnly => false;

    /// <summary>
    /// Gets or sets the element at the specified index.
    /// </summary>
    /// <param name="index">The index of the element to get or set.</param>
    /// <returns>The element at the specified index.</returns>
    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            var current = downHead;

            for (int i = 0; i < index + 1; ++i)
            {
                current = current.Next ?? throw new InvalidOperationException("Navigated past the end of the skip list");

                if (current is null)
                {
                    throw new InvalidOperationException("Navigated past the end of the skip list");
                }
            }

            if (current.Value is null)
            {
                throw new InvalidOperationException("Found null value in skip list");
            }

            return current.Value;
        }
        set => throw new NotSupportedException();
    }

    /// <summary>
    /// Adds an element to the skip list.
    /// </summary>
    /// <param name="value">The element to add.</param>
    public void Add(T value)
    {
        var newSkipListElement = InsertValue(head, value);
        if (newSkipListElement is not null)
        {
            head.Next = new SkipListElement(value, nil, newSkipListElement);
        }

        ++version;
        ++Count;
    }

    /// <summary>
    /// Clears the skip list.
    /// </summary>
    public void Clear()
    {
        head = new (default, nil, default);
        var current = head;
        for (var i = 0; i < MaxLevel - 1; ++i)
        {
            current.Down = new SkipListElement(default, nil, default);
        }

        downHead = current;
        ++version;
        Count = 0;
    }

    /// <summary>
    /// Determines whether the skip list contains the specified element.
    /// </summary>
    /// <param name="value">The element to search for.</param>
    /// <returns>True if the element is found; otherwise, false.</returns>
    public bool Contains(T value)
    {
        var foundValue = FindValue(head, value);
        if (foundValue == downHead)
        {
            return false;
        }

        return value.CompareTo(foundValue.Value) == 0;
    }

    /// <summary>
    /// Copies the elements of the skip list to the specified array, starting at the specified index.
    /// </summary>
    /// <param name="array">The array to copy the elements to.</param>
    /// <param name="arrayIndex">The index in the array to start copying from.</param>
    public void CopyTo(T[] array, int arrayIndex)
    {
        if (array is null)
        {
            throw new ArgumentNullException(nameof(array));
        }

        if (arrayIndex < 0 || arrayIndex >= array.Length)
        {
            throw new IndexOutOfRangeException(nameof(arrayIndex));
        }

        if (array.Length - arrayIndex < Count)
        {
            throw new ArgumentException("The skip list exceeds the allocated space for copying");
        }

        var current = downHead.Next;

        while (current != nil)
        {
            if (current is null || current.Value is null)
            {
                throw new InvalidOperationException("Found null value in skip list");
            }

            array[arrayIndex] = current.Value;

            ++arrayIndex;
            current = current.Next;
        }
    }

    /// <summary>
    /// Returns an enumerator that iterates through the skip list.
    /// </summary>
    /// <returns>An enumerator that iterates through the skip list.</returns>
    public IEnumerator<T> GetEnumerator()
        => new Enumenator(this);

    /// <summary>
    /// Searches for the specified element in the skip list.
    /// </summary>
    /// <param name="value">The element to search for.</param>
    /// <returns>The index of the element if found; otherwise, -1.</returns>
    public int IndexOf(T value)
    {
        var current = downHead.Next;

        var index = 0;
        while (current != nil)
        {
            if (current is null)
            {
                throw new InvalidOperationException("Navigated past the end of the skip list");
            }

            if (value.CompareTo(current.Value) == 0)
            {
                return index;
            }

            current = current.Next;

            ++index;
        }

        return -1;
    }

    /// <summary>
    /// Inserts an element into the skip list at the specified index.
    /// </summary>
    /// <param name="index">The index at which to insert the element.</param>
    /// <param name="value">The element to insert.</param>
    public void Insert(int index, T value)
        => throw new NotSupportedException();

    /// <summary>
    /// Removes the first occurrence of the specified element from the skip list.
    /// </summary>
    /// <param name="value">The element to remove.</param>
    /// <returns>True if the element was removed; otherwise, false.</returns>
    public bool Remove(T value)
    {
        bool wasDeleted = RemoveValue(head, value);

        if (wasDeleted)
        {
            ++version;
            --Count;
        }

        return wasDeleted;
    }

    /// <summary>
    /// Removes the element at the specified index from the skip list.
    /// </summary>
    /// <param name="index">The index of the element to remove.</param>
    public void RemoveAt(int index)
    => Remove(this[index]);

    /// <summary>
    /// Returns an enumerator that iterates through the skip list.
    /// </summary>
    /// <returns>An enumerator that iterates through the skip list.</returns>
    IEnumerator IEnumerable.GetEnumerator()
        => new Enumenator(this);

    /// <summary>
    /// Removes the first occurrence of the specified element from the skip list.
    /// </summary>
    /// <param name="element">The element to remove.</param>
    /// <param name="value">The value of the element to remove.</param>
    private bool RemoveValue(SkipListElement element, T value)
    {
        if (element.Next is null)
        {
            throw new InvalidOperationException("Invalid class");
        }

        while (element.Next != nil && value.CompareTo(element.Next.Value) > 0)
        {
            element = element.Next;

            if (element.Next is null)
            {
                throw new InvalidOperationException("Invalid class");
            }
        }

        if (element.Down is not null)
        {
            bool wasDeleted = RemoveValue(element.Down, value);
            if (wasDeleted)
            {
                return true;
            }
        }

        if (element.Next != nil && value.CompareTo(element.Next.Value) == 0)
        {
            element.Next = element.Next.Next;
            return true;
        }

        return false;
    }

    /// <summary>
    /// Recursively inserts a new element with the specified value into the skip list hierarchy, starting from the given element.
    /// </summary>
    /// <param name="startingElement">The starting point in the skip list hierarchy to insert the new value.</param>
    /// <param name="value">The value to be inserted into the skip list.</param>
    /// <returns>The newly inserted SkipListElement if the coin flip is successful; otherwise, null.</returns>
    private SkipListElement? InsertValue(SkipListElement startingElement, T value)
    {
        // Ensure the starting element is not beyond the end of the skip list
        if (startingElement.Next is null)
        {
            throw new InvalidOperationException("Navigated past the end of the skip list");
        }

        // Traverse the skip list hierarchy to find the appropriate position for the new value
        while (startingElement.Next != nil && value.CompareTo(startingElement.Next.Value) > 0)
        {
            startingElement = startingElement.Next;

            // Check if the next element is unexpectedly null
            if (startingElement.Next is null)
            {
                throw new InvalidOperationException("Navigated past the end of the skip list");
            }
        }

        // Check if the element below is available for potential insertion
        SkipListElement? downElement = startingElement.Down is null ? null : InsertValue(startingElement.Down, value);

        // If the coin flip is successful or there's no element below, insert a new element
        if (downElement is not null || startingElement.Down is null)
        {
            startingElement.Next = new SkipListElement(value, startingElement.Next, downElement);

            if (FlipCoin())
            {
                return startingElement.Next;
            }
        }

        // Return null if the insertion is not successful
        return null;
    }

    /// <summary>
    /// Finds the element with the specified value in the skip list.
    /// </summary>
    /// <param name="result">The result of the previous recursive call.</param>
    /// <param name="value">The value to search for.</param>
    /// <returns>The element with the specified value, or the down head if the value is not found.</returns>
    private SkipListElement FindValue(SkipListElement result, T value)
    {
        // If the next element is null, we have reached the end of the skip list.
        if (result.Next is null)
        {
            throw new InvalidOperationException("Navigated past the end of the skip list");
        }

        // While the next element is not the down head and the value of the next element is less than or equal to the value we are searching for,
        // move to the next element.
        while (result.Next != nil && value.CompareTo(result.Next.Value) >= 0)
        {
            result = result.Next;

            // If the next element is null, we have reached the end of the skip list.
            if (result.Next is null)
            {
                throw new InvalidOperationException("Navigated past the end of the skip list");
            }
        }

        // If the down element is not null, recursively search the down element for the value.
        if (result.Down is not null)
        {
            return FindValue(result.Down, value);
        }

        // Otherwise, return the current element.
        return result;
    }

    /// <summary>
    /// Flips a coin.
    /// </summary>
    /// <returns>True if the coin lands on heads, false if it lands on tails.</returns>
    private bool FlipCoin() => random.Next() % 2 == 0;

    /// <summary>
    /// Enumerator for the skip list.
    /// </summary>
    private class Enumenator : IEnumerator<T>
    {
        private readonly SkipList<T>? skipList;

        private SkipListElement? current;

        private int version;

        /// <summary>
        /// Initializes a new instance of the <see cref="Enumerator"/> class.
        /// </summary>
        /// <param name="skipList">The skip list to enumerate.</param>
        public Enumenator(SkipList<T> skipList)
        {
            current = skipList.downHead;
            this.skipList = skipList;
            version = this.skipList.version;
        }

        /// <summary>
        /// Gets the current element in the enumeration.
        /// </summary>
        public object Current
        {
            get
            {
                if (current is null || current.Value is null)
                {
                    throw new InvalidOperationException("Navigated past the end of the skip list");
                }

                return current.Value;
            }
        }

    /// <summary>
    /// Gets the current element in the enumeration.
    /// </summary>
        T IEnumerator<T>.Current
        {
            get
            {
                if (current is null || current.Value is null)
                {
                    throw new InvalidOperationException("Navigated past the end of the skip list");
                }

                return current.Value;
            }
        }

        /// <summary>
        /// Releases all resources used by the enumerator.
        /// </summary>
        public void Dispose()
            => GC.SuppressFinalize(this);

        /// <summary>
        /// Advances the enumerator to the next element in the skip list.
        /// </summary>
        /// <returns>True if the enumerator was successfully advanced to the next element; false if the enumerator has reached the end of the skip list.</returns>
        public bool MoveNext()
        {
            if (current is null || skipList is null)
            {
                throw new InvalidOperationException("Navigated past the end of the skip list");
            }

            if (version != skipList.version)
            {
                throw new InvalidOperationException("Concurrent modification not allowed");
            }

            if (current.Next == skipList.nil)
            {
                current = skipList.downHead;
                return false;
            }

            current = current.Next;

            return true;
        }

        /// <summary>
        /// Resets the enumerator to the beginning of the skip list.
        /// </summary>
        public void Reset()
        {
            if (skipList is null)
            {
                throw new InvalidOperationException("Navigated past the end of the skip list");
            }

            if (version != skipList.version)
            {
                throw new InvalidOperationException("Concurrent modification not allowed");
            }

            current = skipList.downHead;
        }
    }

    /// <summary>
    /// Represents an element in the skip list.
    /// </summary>
    /// <typeparam name="T">The type of element stored in the skip list.</typeparam>
    private class SkipListElement(T? value, SkipListElement? next, SkipListElement? down)
    {
        /// <summary>
        /// Gets or sets the value of the element.
        /// </summary>
        public T? Value { get; set; } = value;

        /// <summary>
        /// Gets or sets the next element in the skip list.
        /// </summary>
        public SkipListElement? Next { get; set; } = next;

        /// <summary>
        /// Gets or sets the down element in the skip list.
        /// </summary>
        public SkipListElement? Down { get; set; } = down;
    }
}