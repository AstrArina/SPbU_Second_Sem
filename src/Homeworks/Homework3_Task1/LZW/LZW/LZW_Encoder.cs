namespace LZW;

using System.Text;
using Tree;

public class LZWEncoder
{
    private readonly int bitsInByte = 8;

    public string Encode(byte[] byteArray)
    {
        if (byteArray == null || !byteArray.Any())
        {
            throw new ArgumentException("Array can't be null or empty");
        }

        int currentSize = bitsInByte;
        int maxNumberElements = 256;

        var dictionary = new Trie();

        for (int i = 0; i < 256; i++)
        {
            var newElement = new List<byte>();
            newElement.Add((byte)i);
            dictionary.Add(newElement, i);
        }

        var previousBytes = new List<byte>();
        var result = new StringBuilder();

        foreach (var bytes in byteArray)
        {
            var currentElement = new List<byte>();

            currentElement.AddRange(previousBytes);
            currentElement.Add(bytes);

            if (dictionary.Contains(currentElement))
            {
                previousBytes = currentElement;
            }
            else
            {
                if (dictionary.Size == maxNumberElements)
                {
                    ++currentSize;
                    maxNumberElements *= 2;
                }

                var key = dictionary.GetValue(previousBytes);

                result.Append(key.ToString());
                result.Append(" ");

                previousBytes.Clear();
                previousBytes.Add(bytes);
            }
        }

        var lastKey = dictionary.GetValue(previousBytes);
        result.Append(lastKey.ToString());

        return result.ToString();
    }
}
