using System;

namespace ParseTree
{
    public class MyParseTree
    {
        private IParseTreeNode? root;

        public ParseTree(string expression)
        {
            BuildingOfTree(expression);
        }

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
                throw new ArgumentException("Expression contains division by zero");
            }
            catch (ArgumentException)
            {
                throw new ArgumentException("Expression contains unrecognized operation");
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
                var operationNode = new NodeOperation(expression[index][0]);
                index++;

                operationNode.LeftChild = Build(expression, ref index) ?? throw new ArgumentException("Incorrect expression");
                operationNode.RightChild = Build(expression, ref index) ?? throw new ArgumentException("Incorrect expression");

                return operationNode;
            }

            if (double.TryParse(expression[index], out double result))
            {
                index++;
                return new OperandNode(result);
            }

            throw new ArgumentException("Incorrect expression");
        }
    }
}
