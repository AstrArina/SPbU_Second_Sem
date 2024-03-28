using LZW;

if (!(args.Length == 2)) 
{
    Console.WriteLine("Wrong input, try again");
}

if (args[1] == "--c")
{
    double result;

    try 
    {
        result = LZWTransformer.Encode(args[0]);
    }

    catch (ArgumentException) 
    {
        Console.WriteLine("Failed encoding");
        return;
    }

    Console.WriteLine($"Succesfuly encoding. Compression ratio : {result}");
}

else if (args[1] == "-u")
{
    try
    {
        LZWTransformer.Decode(args[0]);
    }

    catch (ArgumentException)
    {
        Console.WriteLine("Failed decoding");
        return;
    }

    Console.WriteLine($"Succesfuly decoding");
}

else 
{
    Console.WriteLine("Wrong input, try again");
}