using PriorityQueue;

namespace Tests;

public class Tests
{
    [Test]
    public void Enqueue_ShouldRight()
    {
        var queue = new Queue();
        queue.Enqueue("turtle", 23);
        queue.Enqueue(21, 38);
        Assert.That(queue.GetElementheadValue(), Is.EqualTo(21));
        Assert.That(queue.GetElementHeadPriority(), Is.EqualTo(38));
        Assert.False(queue.Contains("cat"));
        Assert.True(queue.Contains("turtle"));
    }

    [Test]
    public void EnqueueElementsWithTheSamePriorities()
    {
        var queue = new Queue();
        queue.Enqueue("turtle", 2323);
        queue.Enqueue(16, 2323);
        queue.Enqueue(0.23, 2323);
        Assert.That(queue.GetElementheadValue(), Is.EqualTo("turtle"));
    }

    [Test]
    public void Dequeue_ShouldRight()
    {
        var queue = new Queue();
        queue.Enqueue("turtle", 46);
        queue.Dequeue();
        Assert.True(queue.Empty());
        queue.Enqueue(23, 2121);
        Assert.That(queue.Dequeue(), Is.EqualTo(23));
        Assert.True(queue.Empty());
        queue.Enqueue("cat", 46);
        queue.Enqueue("dog", 69);
        queue.Dequeue();
        Assert.True(queue.Contains("cat"));
        Assert.False(queue.Contains("dog"));
    }

    [Test]
    public void EmptyTest()
    {
        var queue = new Queue();
        Assert.True(queue.Empty());
        queue.Enqueue(23, 21);
        Assert.False(queue.Empty());
    }
}