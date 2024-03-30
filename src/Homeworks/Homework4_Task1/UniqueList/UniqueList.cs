namespace UniqueList;

using System.Collections;

using System.Collections.Generic;

public class UniqueList<T> : MyList<T>
{
    public bool Contain(T element)
    {
        if (head == null)
        {
            return false;
        }

        Node currentNode = head!;

        for (var i = 0; i < Size - 1; ++i)
        {
            if (currentNode.Value!.Equals(element))
            {
                return true;
            }

            currentNode = currentNode.Next!;
        }

        return currentNode.Value!.Equals(element);
    }

    public override void Insert(int index, T element)
    {
        if (Contain(element))
        {
            throw new InvalidInsertOperationException("Element already exists");
        }

        base.Insert(index, element);
    }

    public override void Add(T element)
    {
        if (Contain(element))
        {
            throw new InvalidAddOperationException("Element already exists");
        }

        base.Add(element);
    }

    public override void Change(int index, T element)
    {
        if (Contain(element))
        {
            throw new InvalidChangeOperationException("Element already exists");
        }

        base.Change(index, element);
    }
}