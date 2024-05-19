// Copyright (c) AstrArina. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParseTree;

public class ParseTree()
{
    private IParseTreeNode? root;

    public void BuildingOfTree(string expression)
    {
        ArgumentException.ThrowIfNullOrEmpty(expression);

        expression = expression.Replace('(', ' ');
        expression = expression.Replace(')', ' ');
        var elements = expression.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        var index = 0;
        root = Build(elements, ref index);

        if (index != elements.Length)
        {
            throw new ArgumentException("Incorrect expression");
        }
    }

    public string ExpressionToString()
    {
        if (root is null)
        {
            throw new InvalidOperationException("Empty tree");
        }

        return root.PrintSubTree();
    }

    public double CalculateTree()
    {
       if (root is null)
        {
            throw new InvalidOperationException("Empty tree");
        }

        try
        {
            return root.CalculateSubTree();
        }
        catch (DivideByZeroException)
        {
            throw new ArgumentException("Expression contains wrong operation");
        }
        catch (ArgumentException)
        {
            throw new ArgumentException("Expression contains none declared operation");
        }
    }

    private bool IsOperation(string sign) => sign == "+" || sign == "-" || sign == "*" || sign == "/";

    private IParseTreeNode? Build(string[] expression, ref int index)
    {
        if (index == expression.Length)
        {
            return null;
        }

        if (IsOperation(expression[index]))
        {
            var operationNode = new NodeOperation(expression[index].ToCharArray()[0]);
            ++index;

            operationNode.LeftChild = Build(expression, ref index) ?? throw new ArgumentException("Incorrect expression");
            operationNode.RightChild = Build(expression, ref index) ?? throw new ArgumentException("Incorrect expression");

            return operationNode;
        }

        if (double.TryParse(expression[index], out double result))
        {
            ++index;
            return new OperandNode(result);
        }

        throw new ArgumentException("Incorrect exception");
    }
}
