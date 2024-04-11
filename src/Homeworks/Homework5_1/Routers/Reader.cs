using System.ComponentModel;

namespace Routers;

public class Reader
{
    public static IGraph ReadGraph(string filePath)
    {
        ArgumentException.ThrowIfNullOrEmpty("Empty or null file");

        return (!File.Exists(filePath)) ? throw new FileNotFoundException($"{filePath} not found") : ParseTopology(filePath);
    }

    private static IGraph ParseTopology(string filePath)
    {
        var topology = File.ReadAllText(filePath);

        var parsedTopology = new List<(int, int, int)>();

        var vertexes = new HashSet<int>();

        foreach (var line in topology.Split("\n"))
        {
            var splittedline = line.Split(":");
            if (splittedline.Length != 2)
            {
                throw new ArgumentException("Wrong topology");
            }

            var fromVertex = splittedline[0];
            var toVertexes = splittedline[1].Split(",");

            if (!int.TryParse(fromVertex, out var firstVertex))
            {
                throw new ArgumentException("Wrong topology");
            }

            vertexes.Add(firstVertex);

            foreach (var vert in toVertexes)
            {
                var splittedVert = vert.Split("(");
                var vertex = splittedVert[0];
                if (!int.TryParse(vertex, out var secondVertex))
                {
                    throw new ArgumentException("Wrong topology");
                }

                vertexes.Add(secondVertex);

                if (!int.TryParse(splittedVert[1].Split(")")[0], out var weight) || weight <= 0)
                {
                    throw new ArgumentException("Wrong topology");
                }

                parsedTopology.Add(new (firstVertex - 1, secondVertex - 1, weight));
            }
        }

        var graph = new Graph(vertexes.Max());

        foreach (var edge in parsedTopology)
        {
            graph.AddEdge(edge.Item1, edge.Item2, edge.Item3);
        }

        return graph;
    }
}