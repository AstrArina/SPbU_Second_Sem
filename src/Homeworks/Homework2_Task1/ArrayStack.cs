namespace Stack_Calculator;
public class StackArray : IStack {
    private int FirstElementIndex = -1;
    private int ActualArraySize = 2;
    private float[] stack;
    public StackArray() {
        this.stack = new float[this.ActualArraySize];
    }
    public StackArray(params float[] Numbers) {
        stack = new float[ActualArraySize];
        foreach (var Number in Numbers) {
            Push(Number);
            Console.WriteLine(Number);
        }
    }
    private void NewSizeStack() {
        ActualArraySize *= 2;
        var TemporaryArray = new float[ActualArraySize];
        stack.CopyTo(TemporaryArray,0);
        stack = TemporaryArray;
    }
    public void Push (float NewElement) {
        FirstElementIndex += 1;
        if (FirstElementIndex == ActualArraySize) {
            NewSizeStack();
        }
        stack[FirstElementIndex] = NewElement;
    } 
    public bool EmptyS() => FirstElementIndex == -1;
    public float Pop() {
        if (EmptyS()) {
            throw new InvalidOperationException("Wrong operation");
        }
        FirstElementIndex -= 1;
        return stack[FirstElementIndex + 1];
    }
}