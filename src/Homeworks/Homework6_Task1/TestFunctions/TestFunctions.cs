namespace TestFunctions;

using Functions;

public class Tests
{
    [Test]
    public void MapRightInput()
    {
        var list = new List<byte> {5, 23, 21, 0, 38};

        var expected = new List<int> {7, 25, 23, 2, 40};

        Assert.That(Function.Map(list, a => a + 2), Is.EqualTo(expected));
    }

    [Test]
    public void MapEmptyList()
    {
        var list = new List<int>();

        Assert.That(Function.Map(list, a => a * 8), Is.EqualTo(new List<int>()));
    }

    [Test]
    public void MapWithNull()
    {
        List<char> nullList = null!;

        Assert.Throws<ArgumentNullException>(() => Function.Map(nullList, a => 2 * a));

        var list = new List<int> { 1, 2, 3 };
        Func<int, double> nullFunction = null!;

        Assert.Throws<ArgumentNullException>(() => Function.Map(list, nullFunction));
    }

    [Test]
    public void FilterRightInput()
    {
        var list = new List<string> { "mom", "dad", "sister", "brother" };
    
        var expected = new List<string> { "sister" , "brother"};

        Assert.That(Function.Filter(list, a => a.Contains('t')), Is.EqualTo(expected));
    }    
    
    [Test]
    public void FilterEmptyList()
    {
        var list = new List<char>();

        Assert.That(Function.Filter(list, a => true), Is.EqualTo(new List<char>()));
    }

    [Test]
    public void FilterWithNull()
    {
        List<char> nullList = null!;

        Assert.Throws<ArgumentNullException>(() => Function.Filter(nullList, a => true));

        var list = new List<int> { 1, 2, 3 };
        Func<int, bool> nullFunction = null!;

        Assert.Throws<ArgumentNullException>(() => Function.Filter(list, nullFunction));
    }

    [Test]
    public void FoldRightInput()
    {
        var list = new List<int> { 5, 23, 38 };
    
        var expected = 8740;

        var start = 2;

        Assert.That(Function.Fold(list, start, (a, b) => a * b), Is.EqualTo(expected));
    }    

    [Test]
    public void FoldEmptyList()
    {
        var list = new List<string>();
        var start = "one";

        Assert.That(Function.Fold(list, start, (a, b) => a + b), Is.EqualTo(start));
    }

    [Test]
    public void FoldWithNull()
    {
        List<char> nullList = null!;

        Assert.Throws<ArgumentNullException>(() => Function.Fold(nullList, "one", (a, b) => a + b));

        var list = new List<int> { 1, 2, 3 };
        Func<int, int, int> nullFunction = null!;

        Assert.Throws<ArgumentNullException>(() => Function.Fold(list, 7, nullFunction));
    }
}