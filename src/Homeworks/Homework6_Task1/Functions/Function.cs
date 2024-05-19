namespace Functions;

    /// <summary>
    /// Provides functional operations like Map, Filter, and Fold on lists of elements.
    /// </summary>
    public static class Function
{
    /// <summary>
    /// Applies a function to each element in the list and returns a list of results.
    /// </summary>
    /// <typeparam name="T">The type of elements in the input list.</typeparam>
    /// <typeparam name="TResult">The type of elements in the output list.</typeparam>
    /// <param name="list">The input list of elements to be processed.</param>
    /// <param name="function">The function to apply to each element.</param>
    /// <returns>A list of results after applying the function to each element.</returns>
    public static List<TResult> Map<T, TResult>(List<T> list, Func<T, TResult> function)
    {
        ArgumentNullException.ThrowIfNull(list);
        ArgumentNullException.ThrowIfNull(function);

        var resultArray = new List<TResult>();

        foreach (var element in list)
        {
            resultArray.Add(function(element));
        }

        return resultArray;
    }

    /// <summary>
    /// Filters the elements in the list based on the specified condition function.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    /// <param name="list">The input list of elements to filter.</param>
    /// <param name="function">The condition function to filter elements.</param>
    /// <returns>A list of elements that satisfy the specified condition.</returns>
    public static List<T> Filter<T>(List<T> list, Func<T, bool> function)
    {
        ArgumentNullException.ThrowIfNull(list);
        ArgumentNullException.ThrowIfNull(function);

        var resultArray = new List<T>();

        foreach (var element in list)
        {
            if (function(element))
            {
                resultArray.Add(element);
            }
        }

        return resultArray;
    }

    /// <summary>
    /// Folds the elements in the list using a specified function and initial value.
    /// </summary>
    /// <typeparam name="TResult">The type of the result after folding.</typeparam>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    /// <param name="list">The input list of elements to fold.</param>
    /// <param name="startValue">The initial value for folding.</param>
    /// <param name="function">The function to use for folding.</param>
    /// <returns>The result after folding all elements with the function and initial value.</returns>
    public static TResult Fold<TResult, T>(List<T> list, TResult startValue, Func<TResult, T, TResult> function)
    {
        ArgumentNullException.ThrowIfNull(list);
        ArgumentNullException.ThrowIfNull(function);

        var result = startValue;

        foreach (var element in list)
        {
            result = function(result, element);
        }

        return result;
    }
}