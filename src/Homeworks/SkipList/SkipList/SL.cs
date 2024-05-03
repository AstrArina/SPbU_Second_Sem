namespace SkipList;

using System.Collections;

public class SkipList<T> : IList<T>
    where T : IComparable<T>
{
    private const int MaxLevel = 16;

    private readonly SLElement nil = new (default, default, default);

    private readonly Random random = new ();

    private SLElement downHead;

    private int version;

    private SLElement head;

    public SkipList()
    {
        head = new (default, nil, default);
        var current = head;
        for (var i = 0; i < MaxLevel - 1; ++i)
        {
            current.Down = new SLElement(default, nil, default);
            current = current.Down;
        }

        downHead = current;
    }

    public int Count { get; private set; }

    public bool IsReadOnly => false;

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
                current = current.Next ?? throw new InvalidOperationException("Invalid class");

                if (current is null)
                {
                    throw new InvalidOperationException("Invalid class");
                }
            }

            if (current.Item is null)
            {
                throw new InvalidOperationException("Invalid class");
            }

            return current.Item;
        }
        set => throw new NotSupportedException();
    }

    public void Add(T item)
    {
        SLElement? newSLElement = InsertValue(head, item);
        if (newSLElement is not null)
        {
            head.Next = new SLElement(item, nil, newSLElement);
        }

        ++version;
        ++Count;
    }

    public void Clear()
    {
        head = new (default, nil, default);
        var current = head;
        for (var i = 0; i < MaxLevel - 1; ++i)
        {
            current.Down = new SLElement(default, nil, default);
        }

        downHead = current;
        ++version;
        Count = 0;
    }

    public bool Contains(T item)
    {
        var foundValue = FindValue(head, item);
        if (foundValue == downHead)
        {
            return false;
        }

        return item.CompareTo(foundValue.Item) == 0;
    }

    public void CopyTo(T[] array, int arrIndex)
    {
        if (array is null)
        {
            throw new ArgumentNullException(nameof(array));
        }

        if (arrIndex < 0 || arrIndex >= array.Length)
        {
            throw new IndexOutOfRangeException(nameof(arrIndex));
        }

        if (array.Length - arrIndex < Count)
        {
            throw new ArgumentException("The skip list exceeds the allocated space for copying");
        }

        var current = downHead.Next;

        while (current != nil)
        {
            if (current is null || current.Item is null)
            {
                throw new InvalidOperationException("Invalid class");
            }

            array[arrIndex] = current.Item;

            ++arrIndex;
            current = current.Next;
        }
    }

    public IEnumerator<T> GetEnumerator()
        => new Enumenator(this);

    public int IndexOf(T item)
    {
        var current = downHead.Next;

        var index = 0;
        while (current != nil)
        {
            if (current is null)
            {
                throw new InvalidOperationException("Invalid class");
            }

            if (item.CompareTo(current.Item) == 0)
            {
                return index;
            }

            current = current.Next;

            ++index;
        }

        return -1;
    }

    public void Insert(int index, T item)
        => throw new NotSupportedException();

    public bool Remove(T item)
    {
        var wasDeleted = false;
        RemoveValue(head, item, ref wasDeleted);

        ++version;
        if (wasDeleted)
        {
            --Count;
        }

        return wasDeleted;
    }

    public void RemoveAt(int index)
    => Remove(this[index]);

    IEnumerator IEnumerable.GetEnumerator()
        => new Enumenator(this);

    private void RemoveValue(SLElement element, T item, ref bool wasDeleted)
    {
        if (element.Next is null)
        {
            throw new InvalidOperationException("Invalid class");
        }

        while (element.Next != nil && item.CompareTo(element.Next.Item) > 0)
        {
            element = element.Next;

            if (element.Next is null)
            {
                throw new InvalidOperationException("Invalid class");
            }
        }

        if (element.Down is not null)
        {
            RemoveValue(element.Down, item, ref wasDeleted);
        }

        if (element.Next != nil && item.CompareTo(element.Next.Item) == 0)
        {
            element.Next = element.Next.Next;
            wasDeleted = true;
        }
    }

    private SLElement? InsertValue(SLElement result, T item)
    {
        if (result.Next is null)
        {
            throw new InvalidOperationException("Invalid class");
        }

        while (result.Next != nil && item.CompareTo(result.Next.Item) > 0)
        {
            result = result.Next;

            if (result.Next is null)
            {
                throw new InvalidOperationException("Invalid class");
            }
        }

        SLElement? downElement;
        if (result.Down is null)
        {
            downElement = null;
        }
        else
        {
            downElement = InsertValue(result.Down, item);
        }

        if (downElement is not null || result.Down is null)
        {
            result.Next = new SLElement(item, result.Next, downElement);

            if (FlipCoin())
            {
                return result.Next;
            }
        }

        return null;
    }

    private SLElement FindValue(SLElement result, T item)
    {
        if (result.Next is null)
        {
            throw new InvalidOperationException("Invalid class");
        }

        while (result.Next != nil && item.CompareTo(result.Next.Item) >= 0)
        {
            result = result.Next;

            if (result.Next is null)
            {
                throw new InvalidOperationException("Invalid class");
            }
        }

        if (result.Down is null)
        {
            return result;
        }

        return FindValue(result.Down, item);
    }

    private bool FlipCoin() => random.Next() % 2 == 0;

    private class Enumenator : IEnumerator<T>
    {
        private readonly SkipList<T>? skipList;

        private SLElement? current;

        private int version;

        public Enumenator(SkipList<T> skipList)
        {
            current = skipList.downHead;
            this.skipList = skipList;
            version = this.skipList.version;
        }

        public object Current
        {
            get
            {
                if (current is null || current.Item is null)
                {
                    throw new InvalidOperationException("Invalid class");
                }

                return current.Item;
            }
        }

        T IEnumerator<T>.Current
        {
            get
            {
                if (current is null || current.Item is null)
                {
                    throw new InvalidOperationException("Invalid class");
                }

                return current.Item;
            }
        }

        public void Dispose()
            => GC.SuppressFinalize(this);

        public bool MoveNext()
        {
            if (current is null || skipList is null)
            {
                throw new InvalidOperationException("Invalid class");
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

        public void Reset()
        {
            if (skipList is null)
            {
                throw new InvalidOperationException("Invalid class");
            }

            if (version != skipList.version)
            {
                throw new InvalidOperationException("Concurrent modification not allowed");
            }

            current = skipList.downHead;
        }
    }

    private class SLElement(T? item, SLElement? next, SLElement? down)
    {
        public T? Item { get; set; } = item;

        public SLElement? Next { get; set; } = next;

        public SLElement? Down { get; set; } = down;
    }
}