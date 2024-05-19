namespace Routers;

using System;
using System.IO;
using System.Text;

public class Writer
{
    public static void WriteGraph(IGraph graph, string filePath)
    {
        if (string.IsNullOrEmpty(filePath))
        {
            throw new ArgumentNullException(nameof(filePath));
        }

        var output = new StringBuilder();
        for (var i = 0; i < graph.Size; ++i)
        {
            var outputString = new StringBuilder($"{i + 1} : ");
            foreach (var (neighbour, edgeWeight) in graph.GetNeighbours(i))
            {
                if (neighbour > i)
                {
                    outputString.Append($"{neighbour + 1} ({edgeWeight}) ");
                }
            }

            if (outputString.Length > $"{i + 1} : ".Length)
            {
                output.AppendLine(outputString.ToString().Trim());
            }
        }

        File.WriteAllText(filePath, output.ToString().Trim());
    }
}