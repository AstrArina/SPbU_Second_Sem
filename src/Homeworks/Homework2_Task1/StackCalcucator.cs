namespace Stack_Calculator;
public class Polish_Postfix_Calculator {

    private readonly IStack stack;
    public Polish_Postfix_Calculator(IStack stack) {
        this.stack = stack ?? throw new ArgumentNullException("NULL"); 
    }

    public (float, bool) Calc_Polish_Expression(string Expression) {
        if ((Expression == null) || (Expression == "")) {
            throw new ArgumentException("NULL");
        }
        var ExpressionArray = Expression.Split();
        foreach (var element in ExpressionArray) {
            if (element[0].Operation_Sign() == false) {
                if (float.TryParse(element, out float result) == false) {
                    throw new ArgumentException("Is not a mumber or an operation");
                }
                stack.Push(result);
            }
            else {
                float one_element; 
                float two_element; 
                try {
                    one_element = stack.Pop();
                    two_element = stack.Pop();
                }
                catch {
                    throw new ArgumentException("Wrong expression");
                }
                (var ExpressionResult, var RightExpression) = Calc_Utils.Perform(element[0], two_element, one_element);
                if (RightExpression == false) {
                    return (0.0F, false);
                }
                stack.Push(ExpressionResult);
            }
        }
        float EndResult;
        try {
            EndResult = stack.Pop();
        }
        catch {
            throw new ArgumentException("Wrong expression"); 
        } 
        if (!stack.EmptyS()) {
            throw new ArgumentException("Wrong expression"); 
        }
        return (EndResult, true);
    }
} 