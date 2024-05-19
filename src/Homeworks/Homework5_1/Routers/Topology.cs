namespace Routers
{
    public static class Topology
    {
        public static void Build(string inputFilePath, string outputFile)
        {
            ArgumentException.ThrowIfNullOrEmpty(inputFilePath);
            ArgumentException.ThrowIfNullOrEmpty(outputFile);

            IGraph graph = Reader.ReadGraph(inputFilePath);
            var maxTreeBuilder = new MaxTreeBuilder(graph);
            IGraph maxTree = maxTreeBuilder.MakeFirstAlg();

            Writer.WriteGraph(maxTree, outputFile);
        }
    }
}