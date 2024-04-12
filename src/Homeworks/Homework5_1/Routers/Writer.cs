namespace Routers;

using System.Text;

public class Writer
{
    public static void WriteGraph(IGraph graph, string filePath)
    {
        ArgumentException.ThrowIfNullOrEmpty(nameof(filePath));

        var output = new StringBuilder();
        for (var i = 0; i < graph.Size; ++i)
        {
            var outputString = new StringBuilder($"{i + 1} : ");
            foreach (var (neighbour, edgeWeight) in graph.GetNeighbours(i))
            {
                if (neighbour >= i)
                {
                    outputString.Append($"{neighbour + 1} ({edgeWeight}) ");
                }
            }

            if (outputString.Length > $"{i + 1} : ".Length)
            {
                output.AppendLine(outputString.ToString());
            }
        }

        File.WriteAllText(filePath, output.ToString());
    }
}