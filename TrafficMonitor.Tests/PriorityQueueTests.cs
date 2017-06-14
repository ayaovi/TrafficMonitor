using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace TrafficMonitor.Tests
{
  [TestFixture]
  class PriorityQueueTests
  {
    [Test]
    public void QueueUponCreation_ShouldBeEmpty()
    {
      //Arrange && Act && Assert
      Assert.IsTrue(new PriorityQueue<TrafficEvent>().Queue.Count == 0);
    }
  }

  internal class PriorityQueue <T> where T : IComparable<T>
  {
    public IList<T> Queue { get; set; }
  }
}
