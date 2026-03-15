using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue values with different priorities: Bob(1), Tim(5), Sue(3). Dequeue once.
    // Expected Result: Tim should be removed and returned (highest priority first).
    // Defect(s) Found: Dequeue returned a value but did not remove it from the queue.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Bob", 1);
        priorityQueue.Enqueue("Tim", 5);
        priorityQueue.Enqueue("Sue", 3);

        var value = priorityQueue.Dequeue();
        Assert.AreEqual("Tim", value);
        Assert.AreEqual("[Bob (Pri:1), Sue (Pri:3)]", priorityQueue.ToString());
    }

    [TestMethod]
    // Scenario: Enqueue with a tie on highest priority: Bob(5), Tim(5), Sue(3). Dequeue once.
    // Expected Result: Bob should be removed first (FIFO tie-break among highest priority values).
    // Defect(s) Found: Tie-break selected the most recently seen equal-priority item instead of FIFO.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Bob", 5);
        priorityQueue.Enqueue("Tim", 5);
        priorityQueue.Enqueue("Sue", 3);

        var value = priorityQueue.Dequeue();
        Assert.AreEqual("Bob", value);
        Assert.AreEqual("[Tim (Pri:5), Sue (Pri:3)]", priorityQueue.ToString());
    }

    [TestMethod]
    // Scenario: Enqueue where highest priority is at the end: Bob(1), Tim(2), Sue(9). Dequeue once.
    // Expected Result: Sue should be removed and returned.
    // Defect(s) Found: Highest-priority search skipped the last queue item.
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Bob", 1);
        priorityQueue.Enqueue("Tim", 2);
        priorityQueue.Enqueue("Sue", 9);

        var value = priorityQueue.Dequeue();
        Assert.AreEqual("Sue", value);
        Assert.AreEqual("[Bob (Pri:1), Tim (Pri:2)]", priorityQueue.ToString());
    }

    [TestMethod]
    // Scenario: Dequeue from an empty queue.
    // Expected Result: InvalidOperationException with message "The queue is empty.".
    // Defect(s) Found: No defect found in this scenario.
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                 string.Format("Unexpected exception of type {0} caught: {1}",
                                e.GetType(), e.Message)
            );
        }
    }
}