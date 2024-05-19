using ParseTree;
namespace TestParseTree;

public class TestsParseTree
{
    private ParseTree.ParseTree parseTree;

    [SetUp]
    public void Setup()
    {
        parseTree = new();
    }

    [TestCase("* (- 7 2) (+ 4 (* -3 9))", ExpectedResult = -115)]
    [TestCase("+ (* 7 -9) (- (+ 23 5) (/ 9 3))", ExpectedResult = -38)]
    [TestCase("/ 0 81", ExpectedResult = 0)]
    public double BuildAndCalculateTree(string expression)
    {
        parseTree.BuildingOfTree(expression);
        return parseTree.CalculateTree();
    }

    [TestCase("(/ (- (+ 16 21) 13) (* (- 12 3) 9))")]
    [TestCase("(* (+ (- 11 13) 8) (- 7 (+ 7 23)))")]
    [TestCase("(/ 0 -8)")]
    public void CorrectGetExpressionToString(string expression)
    {
        parseTree.BuildingOfTree(expression);
        Assert.That(expression, Is.EqualTo(parseTree.ExpressionToString()));
    }

    [Test]
    public void CalculateTreeWithDivisionByZero()
    {
        var expression = "(/ 5 0)";

        parseTree.BuildingOfTree(expression);
        Assert.Throws<ArgumentException>(() => parseTree.CalculateTree());
    }

    [TestCase("(* 23 (- y6 9))")]
    [TestCase("23 + 21")]
    [TestCase("7 - ")]
    public void BuildingOfTreeWithIncorrectExpression(string expression)
    {
        Assert.Throws<ArgumentException>(() => parseTree.BuildingOfTree(expression));
    }
}

    [Test]
    public void BuildingOfTreeEmptyExpression()
    {
        Assert.Throws<ArgumentException>(() => parseTree.BuildingOfTree(""));
    }

    [Test]
    public void BuildingOfTreeNullExpression()
    {
        Assert.Throws<ArgumentNullException>(() => parseTree.BuildingOfTree(null!));
    }

    [Test]
    public void CalculateTreeWithoutBuildingTree()
    {
        Assert.Throws<InvalidOperationException>(() => parseTree.CalculateTree());
    }

    [Test]
    public void ExpressionToStringWithoutBuildingTree()
    {
        Assert.Throws<InvalidOperationException>(() => parseTree.ExpressionToString());
    }
}
