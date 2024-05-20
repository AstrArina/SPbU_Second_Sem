namespace TestsSkipList;
using Skip_List;

public class SkipListTests
{
    public void Add_ElementIsAdded()
    {
        SkipList<int> skipList = new SkipList<int>();
        skipList.Add(5);
        Assert.IsTrue(skipList.Contains(5));
    }

    public void Clear_SkipListIsCleared()
    {
        SkipList<int> skipList = new SkipList<int>();
        skipList.Add(10);
        skipList.Clear();
        Assert.That(skipList.Count, Is.EqualTo(0));
        Assert.IsFalse(skipList.Contains(10));
    }

    public void Contains_ReturnsTrueIfElementExists()
    {
        SkipList<int> skipList = new SkipList<int>();
        skipList.Add(15);
        bool contains = skipList.Contains(15);
        Assert.IsTrue(contains);
    }

    public void Indexer_Get_ThrowsExceptionForInvalidIndex()
    {
            SkipList<int> skipList = new SkipList<int>();
        Assert.Throws<ArgumentOutOfRangeException>(() => { var value = skipList[-1]; });
    }

    public void Indexer_Get_ReturnsCorrectValue()
    {
        SkipList<int> skipList = new SkipList<int>();
        skipList.Add(20);
        var value = skipList[0];
        Assert.That(value, Is.EqualTo(20));
    }

    public void Add_MultipleElements_CountIncreasesCorrectly()
    {
        SkipList<int> skipList = new SkipList<int>();
        skipList.Add(1);
        skipList.Add(2);
        skipList.Add(3);
        Assert.That(skipList.Count, Is.EqualTo(3));
    }

    public void Remove_ExistingElement_ElementIsRemoved()
    {
        SkipList<int> skipList = new SkipList<int>();
        skipList.Add(30);
        skipList.Remove(30);
        Assert.IsFalse(skipList.Contains(30));
        Assert.That(skipList.Count, Is.EqualTo(0));
    }

    public void Remove_NonExistingElement_NoChanges()
    {
        SkipList<int> skipList = new SkipList<int>();
        bool result = skipList.Remove(40);
        Assert.IsFalse(result);
        Assert.That(skipList.Count, Is.EqualTo(0));
    }
}
