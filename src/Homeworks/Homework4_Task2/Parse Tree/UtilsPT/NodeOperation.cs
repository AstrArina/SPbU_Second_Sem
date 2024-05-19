// Copyright (c) AstrArina. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParseTree;

public class NodeOperation(char operation) : IParseTreeNode
{
    public char Operation { get; set; } = operation;

    public IParseTreeNode? RightChild { get; set; }

    public IParseTreeNode? LeftChild { get; set; }

    public double CalculateSubTree()
    {
        ArgumentNullException.ThrowIfNull(LeftChild);
        ArgumentNullException.ThrowIfNull(RightChild);

        var left = LeftChild.CalculateSubTree();
        var right = RightChild.CalculateSubTree();
        try
        {
            return CalculateExpression(Operation, left, right);
        }
        catch (ArgumentException)
        {
            throw new ArgumentException("Operation not declared in tree");
        }
        catch (DivideByZeroException)
        {
            throw new DivideByZeroException("Incorrect operation: division by zero");
        }
    }

    public string PrintSubTree() => $"({Operation} {LeftChild?.PrintSubTree()} {RightChild?.PrintSubTree()})";

    private static double CalculateExpression(char operation, double left, double right) =>
        operation switch
        {
            '+' => left + right,
            '-' => left - right,
            '/' => (right == 0) ? throw new DivideByZeroException() : left / right,
            '*' => left * right,
            _ => throw new ArgumentException("Incorrect operation"),
        };
}
