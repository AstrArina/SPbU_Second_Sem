namespace Routers;

public interface IGraph
{
    int Size { get; }

    void AddEdge(int firstVertex, int secondVertex, int len);

    (int, int)[] GetNeighbours(int vertex);
}