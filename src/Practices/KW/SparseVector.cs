using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security;

namespace Vector;
public class SparseVector
{
    Dictionary <int, double> elements;

    public SparseVector()
    {
        elements = new Dictionary<int, double>  ();
    }
    
    public void SetValue(int index, double value)
    {
        if (value != 0)
        {
            elements[index] = value;
        }
        else if (elements.ContainsKey(index))
        {
            elements.Remove(index);
        }
    }

    public double GetValue(int index)
    {
        if (elements.ContainsKey(index))
        {
            return elements[index];
        }
        else
        {
            return 0;
        }
    }

    public SparseVector Add(SparseVector vector)
    {
        SparseVector result = new SparseVector();

        foreach (var pair in elements)
        {
            result.SetValue(pair.Key, pair.Value);
        }

        foreach (var pair in vector.elements)
        {
            result.SetValue(pair.Key, result.GetValue(pair.Key) + pair.Value);
        }

        return result;
    }

    public SparseVector Subtract(SparseVector vector)
    {
        SparseVector result = new SparseVector();

        foreach (var pair in elements)
        {
            result.SetValue(pair.Key, pair.Value);
        }

        foreach (var pair in vector.elements)
        {
            result.SetValue(pair.Key, result.GetValue(pair.Key) - pair.Value);
        }

        return result;
    }

    public double DotProduct(SparseVector vector)
    {
        double product = 0;

        foreach (var pair in elements)
        {
            product += pair.Value * vector.GetValue(pair.Key);
        }

        return product;
    }

    public bool IsZeroVector()
    {
        return elements.Count == 0;
    }
}