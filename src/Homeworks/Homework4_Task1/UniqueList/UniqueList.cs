using System;
using System.Collections;
using System.Collections.Generic;

namespace UniqueList
{
    /// <summary>
    /// Represents a list that stores unique elements of a specific type.
    /// </summary>
    public class UniqueList<T> : MyList<T>
    {
        /// <summary>
        /// Checks if the list contains a specific element.
        /// </summary>
        /// <param name="element">The element to check for.</param>
        /// <returns>True if the element is found, otherwise false.</returns>
        public bool Contains(T element)
        {
            if (head == null)
            {
                return false;
            }

            Node currentNode = head!;

            while (currentNode != null)
            {
                if (currentNode.Value!.Equals(element))
                {
                    return true;
                }

                currentNode = currentNode.Next!;
            }

            return false;
        }

        /// <inheritdoc />
        public override void Insert(int index, T element)
        {
            if (Contains(element))
            {
                throw new InvalidInsertOperationException("Element already exists");
            }

            base.Insert(index, element);
        }

        /// <inheritdoc />
        public override void Add(T element)
        {
            if (Contains(element))
            {
                throw new InvalidAddOperationException("Element already exists");
            }

            base.Add(element);
        }

        /// <inheritdoc />
        public override void Change(int index, T element)
        {
            if (Contains(element))
            {
                throw new InvalidChangeOperationException("Element already exists");
            }

            base.Change(index, element);
        }
    }
}