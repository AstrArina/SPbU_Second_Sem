using TestLZW;
namespace TestLZW;

public class Tests
{
    [TestCase("../../Texts/text.txt")]
    [TestCase("../../Texts/turtle.jpg")]
    public void ResultOfDecodeOfCompressFileIsEqualOriginalFile(string filePath)
    {
        var expected = File.ReadAllBytes(filePath);

        LZWTransformer.Encode(filePath);
        LZWTransformer.Decode(filePath + ".zipped");

        var current = File.ReadAllBytes(filePath);
        File.Delete(filePath + ".zipped");

        Assert.That(expected, Is.EqualTo(current));
    }

    [TestCase("../../Texts/Empty.txt")]
    public void EncodeEmptyFile(string filePath)
    {
        Assert.Throws<ArgumentException>(() => LZWTransformer.Encode(filePath));
    }

    [TestCase("../../Texts/Empty.txt")]
    public void DecodeEmptyFile(string filePath)
    {
        Assert.Throws<ArgumentException>(() => LZWTransformer.Decode(filePath));
    }
    
}