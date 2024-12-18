using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Test a basic priority queue with multiple different priorities.
    // Expected Result: Dequeue returns the value with the highest priority. When two values have the same priority, the first in FIFO order is returned.
    // Defect(s) Found: Dequeue does not find the correct item to remove and it also does not remove the item from the list, but instead returns the item at index 0 of the queue.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low1", 1);
        priorityQueue.Enqueue("High1", 3);
        priorityQueue.Enqueue("Low2", 1);
        priorityQueue.Enqueue("High2", 3);
        priorityQueue.Enqueue("Med1", 2);
        priorityQueue.Enqueue("High3", 3);

        Assert.AreEqual("High1", priorityQueue.Dequeue());
        Assert.AreEqual("High2", priorityQueue.Dequeue());
        Assert.AreEqual("High3", priorityQueue.Dequeue());
        Assert.AreEqual("Med1", priorityQueue.Dequeue());
        Assert.AreEqual("Low1", priorityQueue.Dequeue());
        Assert.AreEqual("Low2", priorityQueue.Dequeue());
        
    }

    [TestMethod]
    // Scenario: Test dequeue when the queue is empty.
    // Expected Result: InvalidOperationException is thrown with the message "The queue is empty.".
    // Defect(s) Found: No defects found here.
    public void TestPriorityQueue_2()
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

    [TestMethod]
     // Scenario: Test enqueuing and dequeuing items with the same priority.
     // Expected Result: Items with the same priority should be dequeued based on FIFO
     // Defect(s) Found: Dequeue does not find the correct item to remove and it also does not remove the item from the list, but instead returns the item at index 0 of the queue.
    public void TestPriorityQueue_SamePriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Item1", 2);
        priorityQueue.Enqueue("Item2", 2);
        priorityQueue.Enqueue("Item3", 2);

       Assert.AreEqual("Item1", priorityQueue.Dequeue());
       Assert.AreEqual("Item2", priorityQueue.Dequeue());
       Assert.AreEqual("Item3", priorityQueue.Dequeue());
    }

   [TestMethod]
     // Scenario: Test enqueuing and dequeuing items with only one priority.
     // Expected Result: Items should be returned in FIFO order as there's only one priority.
     // Defect(s) Found: Dequeue does not find the correct item to remove and it also does not remove the item from the list, but instead returns the item at index 0 of the queue.
    public void TestPriorityQueue_OnePriority()
    {
        var priorityQueue = new PriorityQueue();
         priorityQueue.Enqueue("Item1", 1);
         priorityQueue.Enqueue("Item2", 1);
         priorityQueue.Enqueue("Item3", 1);
         
         Assert.AreEqual("Item1", priorityQueue.Dequeue());
         Assert.AreEqual("Item2", priorityQueue.Dequeue());
         Assert.AreEqual("Item3", priorityQueue.Dequeue());
    }

    [TestMethod]
      // Scenario: Test enqueuing and dequeuing items with no other items in the queue.
      // Expected Result: Should dequeue the one item added in the queue.
      // Defect(s) Found: Dequeue does not find the correct item to remove and it also does not remove the item from the list, but instead returns the item at index 0 of the queue.
    public void TestPriorityQueue_SingleItem()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Item1", 2);

       Assert.AreEqual("Item1", priorityQueue.Dequeue());
    }
}