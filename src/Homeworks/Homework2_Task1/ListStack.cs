namespace Stack_Calculator;
public class StackList : IStack { 
    private readonly List <float> stack = new ();
    public StackList() {
    }
    public StackList(params float[] Objects) {
        foreach (var object1 in Objects) {
            Push(object1);
        }
    }
    public void Push(float NewElement) {
        stack.Insert(0, NewElement);
    }
    public bool EmptyS() => !stack.Any();
    public float Pop() {
        if (EmptyS()) {
            throw new InvalidOperationException("Wrong operation");
        }
        var Temporary = stack[0];
        stack.RemoveAt(0);
        return Temporary;
    }
}
