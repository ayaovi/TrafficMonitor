using System;
using System.Linq;
using NUnit.Framework;

namespace TrafficMonitor.Tests
{
  [TestFixture]
  class TrafficEventTests
  {
    [Test]
    public void EventTimeUponConstruction_GivenArguments_ExpectSuccess()
    {
      //Arrange
      var time = DateTime.Now;
      var @event = new TrafficEvent(time, new Stage(), stage => { stage.Activate(time); });

      //Act && Assert
      Assert.IsTrue(@event.Time == time);
    }

    [Test]
    public void Process_GivenEvent_ExpectSuccess()
    {
      //Arrange
      var lights = Enumerable.Range(0, 4).Select(i => new Light(Colour.Red, new Position(i))).ToList();
      var stages = Enumerable.Range(0, 3).Select(i => new Stage(i) {Lights = lights}).ToList();

      stages[0].Next = stages[1];
      stages[1].Next = stages[2];
      stages[2].Next = stages[0];

      var time = DateTime.Now;
      var @event = new TrafficEvent(time, stages[0], stage => { stage.Activate(time); });

      //Act
      @event.Process();

      //Assert
      Assert.IsTrue(stages[0].IsActive);
    }
  }
}