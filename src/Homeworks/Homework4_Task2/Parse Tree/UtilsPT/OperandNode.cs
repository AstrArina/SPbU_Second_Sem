// Copyright (c) AstrArina. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParseTree;

public class OperandNode(double number) : IParseTreeNode
{
    public double Number { get; set; } = number;

    public double CalculateSubTree() => Number;

    public string PrintSubTree() => $"{Number}";
}
