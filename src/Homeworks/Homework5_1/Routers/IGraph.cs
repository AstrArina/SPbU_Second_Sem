namespace Routers
{
    /// <summary>
    /// Represents an interface for a graph data structure.
    /// </summary>
    public interface IGraph
    {
        /// <summary>
        /// Gets the size of the graph (number of vertices).
        /// </summary>
        int Size { get; }

        /// <summary>
        /// Adds an edge between two vertices in the graph with the specified weight.
        /// </summary>
        /// <param name="firstVertex">The first vertex of the edge.</param>
        /// <param name="secondVertex">The second vertex of the edge.</param>
        /// <param name="len">The weight or length of the edge.</param>
        void AddEdge(int firstVertex, int secondVertex, int len);

        /// <summary>
        /// Gets the neighboring vertices of a given vertex.
        /// </summary>
        /// <param name="vertex">The vertex to get neighbors for.</param>
        /// <returns>An array of tuples representing neighboring vertices and their weights.</returns>
        (int, int)[] GetNeighbours(int vertex);
    }
}