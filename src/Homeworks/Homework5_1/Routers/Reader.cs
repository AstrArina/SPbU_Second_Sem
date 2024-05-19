namespace Routers
{
    /// <summary>
    /// Represents a class for reading graph data from a file.
    /// </summary>
    public class Reader
    {
        /// <summary>
        /// Reads the graph data from the specified file path and returns an IGraph object.
        /// </summary>
        /// <param name="filePath">The path to the file containing the graph data.</param>
        /// <exception cref="ArgumentException">Thrown when filePath is null or empty.</exception>
        /// <exception cref="FileNotFoundException">Thrown when the file specified by filePath is not found.</exception>
        /// <returns>An IGraph object representing the read graph data.</returns>
        public static IGraph ReadGraph(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentException("File path cannot be null or empty.", nameof(filePath));
            }

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"File '{filePath}' not found.");
            }

            return ParseTopology(filePath);
        }

        private static IGraph ParseTopology(string filePath)
        {
            var topology = File.ReadAllText(filePath);
            var parsedTopology = new List<(int, int, int)>();
            var vertexes = new HashSet<int>();

            foreach (var line in topology.Split("\n"))
            {
                var splittedLine = line.Split(":");
                if (splittedLine.Length != 2)
                {
                    throw new NotConnectedGraphException("Invalid topology format");
                }

                if (!int.TryParse(splittedLine[0], out var fromVertex))
                {
                    throw new ArgumentException("Invalid topology format");
                }

                vertexes.Add(fromVertex);

                var toVertices = splittedLine[1].Split(",");
                foreach (var vert in toVertices)
                {
                    var splittedVert = vert.Split("(");
                    if (!int.TryParse(splittedVert[0], out var toVertex))
                    {
                        throw new ArgumentException("Invalid topology format");
                    }

                    vertexes.Add(toVertex);

                    if (!int.TryParse(splittedVert[1].Split(")")[0], out var weight) || weight <= 0)
                    {
                        throw new ArgumentException("Invalid edge weight format or non-positive weight");
                    }

                    parsedTopology.Add((fromVertex - 1, toVertex - 1, weight));
                }
            }

            var graph = new Graph(vertexes.Count);

            foreach (var edge in parsedTopology)
            {
                graph.AddEdge(edge.Item1, edge.Item2, edge.Item3);
            }

            return graph;
        }
    }
}