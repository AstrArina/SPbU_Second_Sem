using System;
using BurrowsWheelerTransformation;

Console.WriteLine("If you want to run the Direct BWT, input '1', if Reverse BWT - '2'");
switch (Console.ReadLine())
{
    case "1":
    {
        Console.WriteLine("Input string: ");
        var inputString = Console.ReadLine();
        if (string.IsNullOrEmpty(inputString))
        {
            Console.WriteLine("Input string should not be null or empty.");
            return;
        }
        var result = BWT.Transform(inputString);
        Console.WriteLine("Transformed string and index of the end of string: {0}, {1}", result.transformedString, result.originalIndex + 1);
        break;
    }
    case "2":
    {
        Console.Write("Input the transformed string: ");
        string transformedString = Console.ReadLine();
        if (string.IsNullOrEmpty(transformedString))
        {
            Console.WriteLine("Transformed string should not be null or empty.");
            return;
        }
        Console.Write("Input the end of the string number: ");
        if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
        {
            Console.WriteLine("Invalid index input.");
            return;
        }
        var originalString = BWT.InverseTransform(transformedString, n);
        Console.WriteLine("String before transformation: {0}", originalString);
        break;
    }
    default:
    {
        Console.WriteLine("Invalid input.");
        break;
    }
}
