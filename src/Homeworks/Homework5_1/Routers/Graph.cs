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
            => (vertex < 0 || vertex >= Size) ? throw new ArgumentException("Incorrect vertex") : graph[vertex].ToArray();
    }
}