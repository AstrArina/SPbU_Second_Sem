using NUnit.Framework;
using System;
using ParseTree;

namespace ParseTreeTests
{
    public class TestsParseTree
    {
        private MyParseTree myParseTree;

        [SetUp]
        public void Setup()
        {
            myParseTree = new MyParseTree("");
        }

        [TestCase("* (- 7 2) (+ 4 (* -3 9))", ExpectedResult = -115)]
        [TestCase("+ (* 7 -9) (- (+ 23 5) (/ 9 3))", ExpectedResult = -38)]
        [TestCase("/ 0 81", ExpectedResult = 0)]
        public double BuildAndCalculateTree(string expression)
        {
            myParseTree.BuildingOfTree(expression);
            return myParseTree.CalculateTree();
        }

        [TestCase("(/ (- (+ 16 21) 13) (* (- 12 3) 9))")]
        [TestCase("(* (+ (- 11 13) 8) (- 7 (+ 7 23)))")]
        [TestCase("(/ 0 -8)")]
        public void CorrectGetExpressionToString(string expression)
        {
            myParseTree.BuildingOfTree(expression);
            Assert.That(expression, Is.EqualTo(myParseTree.ExpressionToString()));
        }

        [Test]
        public void CalculateTreeWithDivisionByZero()
        {
            var expression = "(/ 5 0)";

            myParseTree.BuildingOfTree(expression);
            Assert.Throws<ArgumentException>(() => myParseTree.CalculateTree());
        }

        [TestCase("(* 23 (- y6 9))")]
        [TestCase("23 + 21")]
        [TestCase("7 - ")]
        public void BuildingOfTreeWithIncorrectExpression(string expression)
        {
            Assert.Throws<ArgumentException>(() => myParseTree.BuildingOfTree(expression));
        }

        [Test]
        public void BuildingOfTreeEmptyExpression()
        {
            Assert.Throws<ArgumentException>(() => myParseTree.BuildingOfTree(""));
        }

        [Test]
        public void BuildingOfTreeNullExpression()
        {
            Assert.Throws<ArgumentNullException>(() => myParseTree.BuildingOfTree(null!));
        }

        [Test]
        public void CalculateTreeWithoutBuildingTree()
        {
            Assert.Throws<InvalidOperationException>(() => myParseTree.CalculateTree());
        }

        [Test]
        public void ExpressionToStringWithoutBuildingTree()
        {
            Assert.Throws<InvalidOperationException>(() => myParseTree.ExpressionToString());
        }
    }
}
