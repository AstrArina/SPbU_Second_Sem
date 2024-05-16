using Stack_Calculator;

Console.WriteLine("Input a Polish postfix expression to calculate (elements must be separated by whitespace):");
var expression = Console.ReadLine();

if (string.IsNullOrWhiteSpace(expression))
{
    Console.WriteLine("Empty expression");
    return;
}

var arrayStack = new StackArray();
var calculator = new Polish_Postfix_Calculator(arrayStack);
var (result1, ready1) = calculator.Calc_Polish_Expression(expression);

if (!ready1)
{
    Console.WriteLine("Error: expression contains division by 0");
    return;
}

Console.WriteLine("Array Stack result: {0}", result1);

var listStack = new StackList();
calculator = new Polish_Postfix_Calculator(listStack);
var (result2, ready2) = calculator.Calc_Polish_Expression(expression);

if (!ready2)
{
    Console.WriteLine("Error: expression contains division by 0");
    return;
}

Console.WriteLine("List Stack result: {0}", result2);