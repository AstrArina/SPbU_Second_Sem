using TestLZW;
namespace TestLZW;

public class Tests
{
    [TestCase("../../Texts/text.txt")]
    [TestCase("../../Texts/turtle.jpg")]
    public void ResultOfDecodeOfCompressFileIsEqualOriginalFile(string filePath)
    {
        var expected = filePath.ReadAllBytes(filePath);

        LZWTransform.Encode(filePath);
        LZWTransform.Decode(filePath + ".zipped");

        var current = filePath.ReadAllBytes(filePath);
        File.Delete(filePath + ".zipped");

        Assert.That(expected, Is.EqualTo(current));
    }

    [TestCase("../../Texts/Empty.txt")]
    public void EncodeEmptyFile(string filePath)
    {
        Assert.Throws<ArgumentException>(() => LZWTransform.Encode(filePath));
    }

    [TestCase("../../Texts/Empty.txt")]
    public void DecodeEmptyFile(string filePath)
    {
        Assert.Throws<ArgumentException>(() => LZWTransform.Decode(filePath));
    }
    
}