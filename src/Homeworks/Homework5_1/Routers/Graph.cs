using System.ComponentModel;
using System.Drawing;

namespace Routers;

public class Graph : IGraph
{
    public Graph(int size)
    {
        graph = [];

        for (var i = 0; i < size; ++i)
        {
            graph.Add([]);
        }

        Size = size;
    }

    private readonly List<List<(int, int)>> graph;

    public int Size { get; }

    public void AddEdge(int firstVertex, int secondVertex, int len)
    {
        if (firstVertex < 0 || firstVertex >= Size || secondVertex < 0 || secondVertex >= Size)
        {
            throw new ArgumentException("Incorrect vertex");
        }

        graph[firstVertex].Add((secondVertex, len));
        graph[secondVertex].Add((firstVertex, len));
    }

    public (int, int)[] GetNeighbours(int vertex)
        => (vertex < 0 || vertex >= Size) ? throw new ArgumentException("Incorrect vertex") : [.. graph[vertex]];
}