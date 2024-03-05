namespace BWTTest;

public class Test1
{
    [DataRow("algoritm", "mlratgoi", 1), DataRow("turtle", "lturet", 5), DaraRow(" ", " ", 1)]
    public void DirectTest(string text, string exeptedtext, int exeptedindex) {
        var (originaltext, originalindex) = BWT.Direct(text);
        Assert.IsTrue(originaltext == exeptedtext && originalindex == exeptedindex);
    }

    [DataRow("algoritm", "mlratgoi", 1), DataRow("turtle", "lturet", 5), DaraRow(" ", " ", 1)]
    public void InverseTest(string exeptedtext, string text, int originalindex) {
        var originaltext = BWT.Inverse(text, originalindex);
        Assert.IsTrue(originaltext == exeptedtext);
    }
    
}