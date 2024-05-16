namespace Stack_Calculator.Tests
{
    using Stack_Calculator;
    using NUnit.Framework;
    using System;

    public class StackTests
    {
        private static IEnumerable<TestCaseData> Stacks()
        {
            yield return new TestCaseData(new StackArray()).SetName("ArrayStack");
            yield return new TestCaseData(new StackList()).SetName("ListStack");
        }

        [TestCaseSource(nameof(Stacks))]
        public void Pop_FromEmptyStack_ShouldThrowException(IStack stack)
        {
            Assert.Throws<InvalidOperationException>(() => stack.Pop());
        }

        [TestCaseSource(nameof(Stacks))]
        public void Stack_ShouldBeEmpty_AfterPush(IStack stack)
        {
            var emptyStackResult = stack.IsEmpty();
            stack.Push(777);
            var stackAfterPushResult = stack.IsEmpty();
            Assert.That(emptyStackResult && !stackAfterPushResult, Is.True);
        }

        [TestCaseSource(nameof(Stacks))]
        public void Values_ShouldBePoppedInReverseOrder(IStack stack)
        {
            stack.Push(10);
            stack.Push(20);
            Assert.That(stack.Pop(), Is.EqualTo(20));
            Assert.That(stack.Pop(), Is.EqualTo(10));
        }
    }
}