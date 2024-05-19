namespace Routers
{
    public class MaxTreeBuilder
    {
        private IGraph graph;
        private bool[] visits;
        private int[] primaNeighbour;
        private int[] maxEdge;
        private IGraph maxTree;

        public MaxTreeBuilder(IGraph initGraph)
        {
            if (initGraph == null)
            {
                throw new ArgumentNullException(nameof(initGraph));
            }

            graph = initGraph;
            visits = new bool[initGraph.Size];
            primaNeighbour = new int[initGraph.Size];
            maxEdge = new int[initGraph.Size];
            maxTree = new Graph(initGraph.Size);

            for (var i = 1; i < initGraph.Size; ++i)
            {
                maxEdge[i] = -1;
            }
        }

        public IGraph MakeFirstAlg()
        {
            for (var i = 0; i < graph.Size; ++i)
            {
                var currentVertex = VertexWithMaxEnterEdge();
                UpdateMinTree(currentVertex);
                UpdateNeighbours(currentVertex);
            }

            return maxTree;
        }

        private void UpdateNeighbours(int currentVertex)
        {
            foreach (var (neighbour, len) in graph.GetNeighbours(currentVertex))
            {
                if (len > maxEdge[neighbour])
                {
                    maxEdge[neighbour] = len;
                    primaNeighbour[neighbour] = currentVertex;
                }
            }
        }

        private void UpdateMinTree(int currentVertex)
        {
            if (currentVertex != 0 && maxEdge[currentVertex] == -1)
            {
                throw new NotConnectedGraphException("Incorrect graph");
            }

            maxTree.AddEdge(primaNeighbour[currentVertex], currentVertex, maxEdge[currentVertex]);
        }

        private int VertexWithMaxEnterEdge()
        {
            var currentVertex = -1;
            for (var vertex = 0; vertex < graph.Size; ++vertex)
            {
                if (!visits[vertex] && (currentVertex == -1 || maxEdge[vertex] > maxEdge[currentVertex]))
                {
                    currentVertex = vertex;
                }
            }

            visits[currentVertex] = true;

            return currentVertex;
        }

        private void InitializeParameters(IGraph initGraph)
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
}