// Copyright (c) AstrArina. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.
using ParseTree;

if (args.Length != 1)
{
    Console.WriteLine("Error. Use \"dotnet run help\"");
    return;
}

if (args[0] == "help")
{
    Console.WriteLine("<dotnet run --project=projectPath FilePath> will calculate infix expression");
}

if (!File.Exists(args[0]))
{
    Console.WriteLine("File not found");
    return;
}

var expression = File.ReadAllText(args[0]);
MyParseTree parseTree;
try
{
    parseTree = new MyParseTree(expression);
}
catch (ArgumentException e)
{
    Console.Write(e.Message);
    return;
}

double result;
try
{
    result = parseTree.CalculateTree();
}
catch (Exception e) when (e is ArgumentException || e is DivideByZeroException)
{
    Console.Write(e.Message);
    return;
}

Console.WriteLine($"{parseTree.ExpressionToString()} = {result}");
