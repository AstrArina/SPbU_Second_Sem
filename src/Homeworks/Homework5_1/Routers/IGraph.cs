namespace Routers
{
    public interface IGraph
    {
        public int Size { get; }

        public void AddEdge(int startVertex, int endVertex, int length);

        public (int vertex, int length)[] GetNeighbours(int vertex);
    }
}