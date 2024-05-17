namespace BubbleSort
{
    /// <summary>
    /// Class containing a method to sort a list using the bubble sort algorithm.
    /// </summary>
    /// <typeparam name="T">Type of elements in the list.</typeparam>
    public static class MyBubbleSort<T>
    {
        /// <summary>
        /// Sorts a list using the bubble sort algorithm.
        /// </summary>
        /// <param name="list">The list to be sorted.</param>
        /// <param name="comparer">The comparer used to compare elements of type T.</param>
        /// <returns>The sorted list.</returns>
        public static IList<T> Sorter(IList<T> list, IComparer<T> comparer)
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list), "The input list cannot be null.");
            }

            if (comparer == null)
            {
                throw new ArgumentNullException(nameof(comparer), "The comparer cannot be null.");
            }

            bool mark;
            for (int i1 = 0; i1 < list.Count; ++i1)
            {
                mark = false;
                for (int i2 = 0; i2 < list.Count - 1; ++i2)
                {
                    if (comparer.Compare(list[i2], list[i2 + 1]) > 0)
                    {
                        Change(list, i2, i2 + 1);
                        mark = true;
                    }
                }

                if (!mark)
                {
                    break;
                }
            }

            return list;
        }

        /// <summary>
        /// Swaps elements at the specified indices in the list.
        /// </summary>
        /// <param name="list">List whose elements need to be changed.</param>
        /// <param name="firstIndex">The first index of list element.</param>
        /// <param name="secondIndex">The second index of list element.</param>
        private static void Change(IList<T> list, int firstIndex, int secondIndex)
        {
            if (firstIndex < 0 || firstIndex >= list.Count || secondIndex < 0 || secondIndex >= list.Count)
            {
                throw new ArgumentOutOfRangeException("Indices are out of range.");
            }

            T temp = list[firstIndex];
            list[firstIndex] = list[secondIndex];
            list[secondIndex] = temp;
        }
    }
}