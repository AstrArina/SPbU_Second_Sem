namespace Stack_Calculator;
public static class Calc_Utils {
    public static bool Operation_Sign(this char value) => value == '-' || value == '+' || value == '/' || value == '*';
    public static (float, bool) Perform(char operation, float oneNumber, float twoNumber) {
        switch (operation) {
            case '-':
                return (oneNumber - twoNumber, true);
            case '+':
                return (oneNumber + twoNumber, true);
            case '/': {
                const float eps = 0.00001F;
                return Math.Abs(0.0F - twoNumber) < eps
                    ? (0.0F, false)
                    :(oneNumber / twoNumber, true);
            }
            case '*':
                return (oneNumber * twoNumber, true);
            default:
                throw new ArgumentException("Is not operation");
        }
    }
}