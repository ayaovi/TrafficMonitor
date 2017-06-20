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
      Assert.IsTrue(new PriorityQueue<TrafficEvent>().Count == 0);
    }

    [Test]
    public void Peek_GivenQueue_ExpectSuccess()
    {
      //Arrange
      var queue = new PriorityQueue<TrafficEvent>();
      var time = DateTime.Now;
      var @event = new TrafficEvent(time, new TimeSpan(3), new Stage(), stage => stage.Activate(time));

      //Act
      queue.Add(@event);

      //Assert
      Assert.IsTrue(queue.Peek().Equals(@event));
    }

    [Test]
    public void Pop_GivenGivenQueue_ExpectSuccess()
    {
      //Arrange
      var queue = new PriorityQueue<TrafficEvent>();
      var time = DateTime.Now;
      var @event = new TrafficEvent(time, new TimeSpan(3), new Stage(), stage => stage.Activate(time));

      //Act
      queue.Add(@event);
      var event1 = queue.Pop();

      //Assert
      Assert.IsTrue(queue.Count == 0);
      Assert.IsTrue(event1.Equals(@event));
    }

    [Test]
    public void Add_GivenTrafficEvent_ExpectSuccess()
    {
      //Arrange
      var queue = new PriorityQueue<TrafficEvent>();
      var time = DateTime.Now;
      var @event = new TrafficEvent(time, new TimeSpan(3), new Stage(), stage => stage.Activate(time));
      var event1 = new TrafficEvent(new DateTime(30), new TimeSpan(3), new Stage(1), stage => stage.Activate(time));

      //Act
      queue.Add(@event);
      queue.Add(event1);

      //Assert
      Assert.IsTrue(queue.Count == 2);
      Assert.IsTrue(queue.Peek().Equals(event1));
    }
  }
}