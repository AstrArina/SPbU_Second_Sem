using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;

using MySparseVector;

    SparseVector vector1 = new SparseVector();
    SparseVector vector2 = new SparseVector();

    vector1.SetValue(0, 1);
    vector1.SetValue(1, 2);
    vector1.SetValue(3, 4);

    vector2.SetValue(1, 3);
    vector2.SetValue(2, 5);

    SparseVector sumVector = vector1.Add(vector2);
    SparseVector difVector = vector2.Subtract(vector2);
    double dotProduct = vector1.DotProduct(vector2);
    bool isVectorsZero = vector1.IsZeroVector();

    Console.WriteLine("Sum:");
    foreach(var pair in sumVector.elements)
    {
        Console.WriteLine($"Index: {pair.Key}, Value: {pair.Value}");
    }

    Console.WriteLine("Difference:");
    foreach(var pair in difVector.elements)
    {
        Console.WriteLine($"Index: {pair.Key}, Value: {pair.Value}");
    }

    Console.WriteLine($"Dot product: {dotProduct}");
    Console.WriteLine($"Is Zero vector: {isVectorsZero}");


