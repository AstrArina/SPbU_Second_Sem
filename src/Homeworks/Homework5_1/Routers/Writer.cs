using System;
using System.IO;
using System.Text;

namespace Routers
{
    /// <summary>
    /// Represents a class for writing graph data to a file.
    /// </summary>
    public class Writer
    {
        /// <summary>
        /// Writes the graph data to the specified file path.
        /// </summary>
        /// <param name="graph">The graph object to write.</param>
        /// <param name="filePath">The file path to write the data to.</param>
        /// <exception cref="ArgumentNullException">Thrown when filePath is null or empty.</exception>
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
}