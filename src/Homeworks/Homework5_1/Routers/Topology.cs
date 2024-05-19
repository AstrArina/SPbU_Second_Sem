namespace Routers
{
    /// <summary>
    /// Provides methods to build a topology and perform operations on graphs.
    /// </summary>
    public static class Topology
    {
        /// <summary>
        /// Builds a topology based on the input file and writes the resulting graph to an output file.
        /// </summary>
        /// <param name="inputFilePath">The input file containing the graph data to build the topology.</param>
        /// <param name="outputFile">The output file where the built graph will be written.</param>
        /// <exception cref="ArgumentException">Thrown when inputFilePath or outputFile is null or empty.</exception>
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