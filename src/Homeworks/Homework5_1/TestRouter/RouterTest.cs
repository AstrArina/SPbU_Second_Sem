    namespace TestRouter;

    using Routers;

    public class RouterTopologyTests
    {
        [TestCase("../../../TestFiles/rightInput1.txt", "../../../TestFiles/expectedOutput1.txt")]
        [TestCase("../../../TestFiles/rightInput2.txt", "../../../TestFiles/expectedOutput2.txt")]
        public void BuildRightInput(string inputFile, string expectedFile)
        {
            Topology.Build(inputFile, "../../../TestFiles/output.txt");
            Assert.That(File.ReadAllText("../../../TestFiles/output.txt"), Is.EqualTo(File.ReadAllText(expectedFile)));
        }

        [Test]
        public void BuildNullOrEmptyInput()
        {
            Assert.Throws<ArgumentException>(() => Topology.Build(string.Empty, "cat"));
            Assert.Throws<ArgumentNullException>(() => Topology.Build(null!, "dog"));
            Assert.Throws<ArgumentException>(() => Topology.Build("frog", string.Empty));
            Assert.Throws<ArgumentNullException>(() => Topology.Build("bird", null!));
        }

        [Test]
        public void BuildUnexisterFile()
        {
            Assert.Throws<FileNotFoundException>(() => Topology.Build("file1.txxt", "file2.txt"));
        }

        [TestCase("../../../TestFiles/disconnectedgraph1.txt")]
        [TestCase("../../../TestFiles/disconnectedgraph2.txt")]
        public void BuildDisconnectedGraph(string inputFile)
        {
            Assert.Throws<NotConnectedGraphException>(() => Topology.Build(inputFile, "../../../TestFiles/output.txt"));
        }

        [TestCase("../../../TestFiles/incorrectedInput1.txt")]
        [TestCase("../../../TestFiles/incorrectedInput2.txt")]
        [TestCase("../../../TestFiles/incorrectedInput3.txt")]
        public void BuildIncorrectInput(string inputFile)
        {
            Assert.Throws<ArgumentException>(() => Topology.Build(inputFile, "../../../TestFiles/output.txt"));
        }
    }