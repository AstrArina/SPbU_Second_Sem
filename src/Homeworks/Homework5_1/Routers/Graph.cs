namespace Routers
{
    public class Graph : IGraph
    {
        private readonly List<List<(int, int)>> graph;

        public Graph(int size)
        {
            graph = new List<List<(int, int)>>(size);

            for (var i = 0; i < size; ++i)
            {
                graph.Add(new List<(int, int)>());
            }

            Size = size;
        }

        /// <summary>
        /// Gets the size of the graph (number of vertices).
        /// </summary>
        public int Size { get; }

        /// <summary>
        /// Adds an edge between two vertices in the graph with the specified weight.
        /// </summary>
        /// <param name="firstVertex">The first vertex of the edge.</param>
        /// <param name="secondVertex">The second vertex of the edge.</param>
        /// <param name="lenght">The weight or length of the edge.</param>
        /// <exception cref="ArgumentException">Thrown when vertices are incorrect.</exception>
        public void AddEdge(int firstVertex, int secondVertex, int lenght)
        {
            if (firstVertex < 0 || firstVertex >= Size || secondVertex < 0 || secondVertex >= Size)
            {
                throw new ArgumentException("Incorrect vertex");
            }

            graph[firstVertex].Add((secondVertex, lenght));
            graph[secondVertex].Add((firstVertex, lenght));
        }

        /// <summary>
        /// Gets the neighboring vertices of a given vertex.
        /// </summary>
        /// <param name="vertex">The vertex to get neighbors for.</param>
        /// <returns>An array of tuples representing neighboring vertices and their weights.</returns>
        /// <exception cref="ArgumentException">Thrown when vertex is incorrect.</exception>
        public (int, int)[] GetNeighbours(int vertex)
            => (vertex < 0 || vertex >= Size) ? throw new ArgumentException("Incorrect vertex") : graph[vertex].ToArray();
    }
}