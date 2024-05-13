using NUnit.Framework;
using System;

namespace BurrowsWheelerTransformation
{
    public class BWTTests
    {
        [TestCase("algoritm", ExpectedResult = "(gmilator, 1)")]
        [TestCase("turtle", ExpectedResult = "(elrtut, 5)")]
        [TestCase(" ", ExpectedResult = "( , 1)")]
        public string TransformTest(string inputText)
        {
            var result = BWT.Transform(inputText);
            return $"({result.transformedString}, {result.originalIndex})";
        }

        [TestCase("(gmilator, 1)", ExpectedResult = "algoritm")]
        [TestCase("(elrtut, 5)", ExpectedResult = "turtle")]
        [TestCase("( , 1)", ExpectedResult = " ")]
        public string InverseTransformTest(string bwtString)
        {
            var parts = bwtString.Trim('(', ')').Split(", ");
            var result = BWT.InverseTransform(parts[0], int.Parse(parts[1]));
            return result;
        }
    }
}
