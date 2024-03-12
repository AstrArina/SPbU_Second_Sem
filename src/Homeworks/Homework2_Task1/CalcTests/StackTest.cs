namespace Stack_Calculator_Tests;
using Stack_Calculator;
public class StackTests {
    private static IEnurable<TestCaseData> Stack() {
        yield return new TestCaseData(new StackList());
        yield return new TestCaseData(new StackArray());
    }
    [TestCaseSource(nameof(Stack))]
    public void Pop_EmptyStack_ThrowResult(IStack stack) {
        Assert.Throws(typeof(InvalidOperatoinException), () => stack.Pop());
    }
    [TestCaseSource(nameof(Stack))]
    public void Empty_AfterPop_CorrectResult(IStack stack) {
        var emptyResult = stack.EmptyS();
        stack.Push(56756);
        var afterPushResult = stack.EmptyS();
        stack.Pop();
        var afterPopResult = stack.EmptyS();
        Assert.That(emptyResult && !afterPushResult && afterPopResult);
    }
    [TestCaseSource(nameof(Stack))]
    public void PopPush_correctWork(IStack stack) {
        stack.Push(5);
        stack.Push(23);
        Assert.That(stack.Pop() == 23 && stack.Pop() == 5);
    }
}
