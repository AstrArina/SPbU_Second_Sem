namespace Functions;

public static class Function
{
    public static List<TResult> Map<T, TResult>(List<T> list, Func<T, TResult> function)
    {
        ArgumentNullException.ThrowIfNull(list);
        ArgumentNullException.ThrowIfNull(function);

        var resultArr = new List<TResult>();

        foreach (var element in list)
        {
            resultArr.Add(function(element));
        }

        return resultArr;
    }

    public static List<T> Filter<T>(List<T> list, Func<T, bool> function)
    {
        ArgumentNullException.ThrowIfNull(list);
        ArgumentNullException.ThrowIfNull(function);

        var resultArr = new List<T>();

        foreach (var element in list)
        {
            if (function(element))
            {
                resultArr.Add(element);
            }
        }

        return resultArr;
    }

    public static TResult Fold<TResult, T>(List<T> list, TResult startValue, Func<TResult, T, TResult> function)
    {
        ArgumentNullException.ThrowIfNull(list);
        ArgumentNullException.ThrowIfNull(function);

        TResult result = startValue;

        foreach (var element in list)
        {
            result = function(result, element);
        }

        return result;
    }
}