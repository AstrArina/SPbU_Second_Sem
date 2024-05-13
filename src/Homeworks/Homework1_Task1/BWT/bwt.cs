namespace BurrowsWheelerTransformation
{
    using System;
    using System.Text;

    public static class BWT
    {
        public static (string transformedString, int originalIndex) Transform(string inputText)
        {
            if (string.IsNullOrEmpty(inputText))
            {
                throw new ArgumentException("Input text should not be null or empty.", nameof(inputText));
            }

            string[] cyclicPermutations = new string[inputText.Length];
            cyclicPermutations[0] = inputText;

            for (int i = 0; i < inputText.Length - 1; i++)
            {
                cyclicPermutations[i + 1] = cyclicPermutations[i][1..] + cyclicPermutations[i][0];
            }

            Array.Sort(cyclicPermutations);

            StringBuilder transformedOutput = new StringBuilder();
            foreach (string permutation in cyclicPermutations)
            {
                transformedOutput.Append(permutation[^1]);
            }

            int originalIndex = Array.IndexOf(cyclicPermutations, inputText);
            return (transformedOutput.ToString(), originalIndex);
        }

        public static string InverseTransform(string bwtString, int index)
        {
            if (string.IsNullOrEmpty(bwtString))
            {
                throw new ArgumentException("BWT string should not be null or empty.", nameof(bwtString));
            }

            string[] sortedPermutations = new string[bwtString.Length];
            for (int j = 0; j < bwtString.Length; j++)
            {
                for (int i = 0; i < bwtString.Length; i++)
                {
                    sortedPermutations[i] = bwtString[i] + sortedPermutations[i];
                }

                Array.Sort(sortedPermutations);
            }

            return sortedPermutations[index - 1];
        }
    }
}
