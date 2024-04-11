namespace Routers;

public static class Topology
{
    public static void Build(string inputfilePath, string outputFile)
    {
        ArgumentException.ThrowIfNullOrEmpty(inputfilePath);
        ArgumentException.ThrowIfNullOrEmpty(outputFile);

        IGraph graph = Reader.ReadGraph(inputfilePath);

        IGraph maxTree = MaxTreeBuilder.MakeFirstAlg(graph);

        Writer.WriteGraph(maxTree, outputFile);
    }
}