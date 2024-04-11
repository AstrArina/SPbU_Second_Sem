using System.Reflection.Metadata.Ecma335;

namespace Routers;

public static class MaxTreeBuilder
{
    private static IGraph? graph;

    private static bool[]? visits;

    private static int[]? primaNeighbour;

    private static int[]? maxEdge;

    private static IGraph? maxTree;

    public static IGraph MakeFirstAlg(IGraph initGraph)
    {
        ArgumentNullException.ThrowIfNull(initGraph);

        InitializeParameters(initGraph);

        for (var i = 0; i < graph!.Size; ++i)
        {
            var currentVertex = VertexWithMaxEnterEdge();

            UpdateMinTree(currentVertex);

            UpdateNeighbours(currentVertex);
        }

        return maxTree!;
    }

    private static void UpdateNeighbours(int currentVertex)
    {
        foreach (var (neighbour, len) in graph!.GetNeighbours(currentVertex))
        {
            if (len > maxEdge![neighbour])
            {
                maxEdge[neighbour] = len;
                primaNeighbour![neighbour] = currentVertex;
            }
        }
    }

    private static void UpdateMinTree(int currentVertex)
    {
        if (currentVertex != 0)
        {
            if (maxEdge![currentVertex] == -1)
            {
                throw new NotConnectedGraphException("Incorrect graph");
            }

            maxTree!.AddEdge(primaNeighbour![currentVertex], currentVertex, maxEdge![currentVertex]);
        }
    }

    private static int VertexWithMaxEnterEdge()
    {
        var currentVertex = -1;
        for (var vertex = 0; vertex < graph!.Size; ++vertex)
        {
            if (!visits![vertex] && (currentVertex == -1 || maxEdge![vertex] > maxEdge![currentVertex]))
            {
                currentVertex = vertex;
            }
        }

        visits![currentVertex] = true;

        return currentVertex;
    }

    private static void InitializeParameters(IGraph initGraph)
    {
        visits = new bool[initGraph.Size];
        primaNeighbour = new int[initGraph.Size];
        maxEdge = new int[initGraph.Size];
        maxTree = new Graph(initGraph.Size);
        for (var i = 1; i < initGraph.Size; ++i)
        {
            maxEdge[i] = -1;
        }

        graph = initGraph;
    }
}