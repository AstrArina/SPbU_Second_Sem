namespace Routers
{
    /// <summary>
    /// Class for constructing a maximum spanning tree.
    /// </summary>
    public class MaxTreeBuilder
    {
        private IGraph graph;
        private bool[] visits;
        private int[] primaNeighbour;
        private int[] maxEdge;
        private IGraph maxTree;

        /// <summary>
        /// Constructor of the MaxTreeBuilder class.
        /// </summary>
        /// <param name="initGraph">The graph based on which the tree will be built.</param>
        public MaxTreeBuilder(IGraph initGraph)
        {
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

        /// <summary>
        /// Method to perform the first tree construction algorithm.
        /// </summary>
        /// <returns>The maximum spanning tree.</returns>
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

        /// <summary>
        /// Updates the neighboring vertices of the current vertex if a longer edge is found.
        /// </summary>
        /// <param name="currentVertex">The current vertex.</param>
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

        /// <summary>
        /// Updates the tree of minimum paths.
        /// </summary>
        /// <param name="currentVertex">The current vertex.</param>
        private void UpdateMinTree(int currentVertex)
        {
            if (currentVertex != 0 && maxEdge[currentVertex] == -1)
            {
                throw new NotConnectedGraphException("Incorrect graph");
            }

            maxTree.AddEdge(primaNeighbour[currentVertex], currentVertex, maxEdge[currentVertex]);
        }

        /// <summary>
        /// Returns the vertex with the maximum incoming edge.
        /// </summary>
        /// <returns>The vertex with the maximum incoming edge.</returns>
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
    }
}