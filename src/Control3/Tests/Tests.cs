using System.Collections.Generic;
using Xunit;

namespace BubbleSort_Tests
{
    public class BubbleSortTests
    {
        [Fact]
        public void Sorter_IntList()
        {
            List<int> list = new List<int> { 5, 2, 1, 8, 4, 9, 7, 3, 6, 0 };

            var sortedList = BubbleSort.MyBubbleSort<int>.Sorter(list, Comparer<int>.Default);

            Assert.Equal(list.OrderBy(x => x), sortedList);
        }

        [Fact]
        public void Sorter_StringList()
        {
            List<string> list = new List<string> { "apple", "dog", "cat" };

            var sortedList = BubbleSort.MyBubbleSort<string>.Sorter(list, Comparer<string>.Default);

            Assert.Equal(list.OrderBy(x => x), sortedList);
        }

        [Fact]
        public void Sorter_EmptyList()
        {
            var unsortedList = new List<int>();

            IList<int> sortedList = BubbleSort.MyBubbleSort<int>.Sorter(unsortedList, Comparer<int>.Default);
            Assert.Empty(sortedList);
        }
    }
}