namespace Test.Calculator;

public class Tests
{
    [SetUp]
    public void Setup()
    {
        var tree = new Trie();
    }

    [TestCase(true, 1, 2, 3, 4, 5)]
    public void CorrectContain(bool expected, params int[] array)
    {
        var actual = true;
        foreach (var element in array)
        {
            if (!tree.Contain(element))
            {
                actual = false;
            }
        }

        Assert.That(actual == expected);
    }

    [Test]
    public void IncorrectInputThrowException()
    {
        Assert.Throws<ArgumentNullException>(() => )
    }
}
