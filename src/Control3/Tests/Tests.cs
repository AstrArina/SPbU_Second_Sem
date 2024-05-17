using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using BubbleSort;
using Newtonsoft.Json.Serialization;
namespace BubbleSort_Tests;

public class BubbleSortTests
{
    [Test]
    public void Sorter_IntList()
    {
        var unsortedList = new List<int> {3, 1, 4, 1, 5, 9, 2, 6, 5, 3};

        IList<int> sortedList = MyBubbleSort<int>.Sorter(unsortedList, Comparer<int>.Default);
        Assert.That(new List<int> {1, 1, 2, 3, 3, 4, 5, 5, 6, 9}, Is.EqualTo(sortedList));
    }

    [Test]
    public void Sorter_StringList()
    {
        var unsortedList = new List<string> {"turtle", "cat", "dog"};

        IList<string> sortedList = MyBubbleSort<string>.Sorter(unsortedList, Comparer<string>.Default);
        Assert.That(new List<string> {"cat", "dog", "turtle"}, Is.EqualTo(sortedList));
    }

    [Test]
    public void Sorter_EmptyList()
    {
        var unsortedList = new List<int>();

        IList<int> sortedList = MyBubbleSort<int>.Sorter(unsortedList, Comparer<int>.Default);
        Assert.IsEmpty(sortedList);
    }
}