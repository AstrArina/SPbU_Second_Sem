using Stack_Calculator;
Console.WriteLine("Input polish postfix expression to calculate (elements must be separated by whitespace)");
var Expression = Console.ReadLine();
if (Expression == null) {
    Console.WriteLine("Empty expression");
    return;
}
var AStack = new StackArray();
var Calculator = new Polish_Postfix_Calculator(AStack);
(var Result, var Ready) = Calculator.Calc_Polish_Expression(Expression);
if (Ready == false) {
    Console.WriteLine("Arror: expression contains dividing by 0");
    return;
}
Console.WriteLine("Array Stack result: {0}", Result);

var LStack = new StackList();
Calculator = new Polish_Postfix_Calculator(LStack);
(Result, Ready) = Calculator.Calc_Polish_Expression(Expression);
if (!Ready) {
    Console.WriteLine("Arror: expression contains dividing by 0");
    return;
}
Console.WriteLine("List Stack result: {0}", Result); 
