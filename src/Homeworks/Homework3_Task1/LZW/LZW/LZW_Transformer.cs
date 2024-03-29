namespace LZW;

public static class LZWTransformer
{
    public static double Encode(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new ArgumentException("File with this file-path does not exist");
        }

        var fileByteNumber = File.ReadAllBytes(filePath);

        if (fileByteNumber == null || !fileByteNumber.Any())
        {
            throw new ArgumentException("Empty file");
        }

        var newFilePath = filePath + ".zipped";

        var text = new LZWEncoder();

        File.WriteAllText(newFilePath, text.Encode(fileByteNumber));

        var sizeOfOriginal = new FileInfo(filePath).Length;
        var sizeOfNew = new FileInfo(newFilePath).Length;

        return (double)sizeOfOriginal / sizeOfNew;
    }

    public static void Decode(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new ArgumentException("File with this file-path does not exist");
        }

        var encodeFile = File.ReadAllText(filePath);

        if (encodeFile == null || !encodeFile.Any())
        {
            throw new ArgumentException("Empty file");
        }

        var encodeArray = encodeFile.Split(" ");

        var newFilePath = filePath.Substring(0, filePath.LastIndexOf('.'));

        var decodeText = new LZWDecoder();

        File.WriteAllBytes(newFilePath, decodeText.Decode(encodeArray));
    }
}