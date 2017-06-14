using System;
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
      var lights = new[]
      {
        new Light(Colour.Red, new Position(0)),
        new Light(Colour.Red, new Position(1)),
        new Light(Colour.Red, new Position(2))
      };

      var stages = new[]
      {
        new Stage {Lights = lights},
        new Stage(1) {Lights = lights},
        new Stage(2) {Lights = lights}
      };

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

  internal class TrafficEvent
  {
    public TrafficEvent(DateTime time, Stage stage, Action<Stage> callback)
    {
      Time = time;
      Stage = stage;
      CallBack = callback;
    }

    public Stage Stage { get; set; }

    public Action<Stage> CallBack { get; set; }

    public DateTime Time { get; }

    public void Process()
    {
      CallBack(Stage);
    }
  }
}
