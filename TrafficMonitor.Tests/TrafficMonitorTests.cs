using System;
using NUnit.Framework;

namespace TrafficMonitor.Tests
{
  [TestFixture]
  public class TrafficMonitorTests
  {
    [Test]
    public void Creation_ExpectSuccess()
    {
      //Arrange
      var controller = new TrafficMonitor { SystemTime = DateTime.Now };

      //Assert
      Assert.IsTrue(controller.Lights.Count == 4);
      Assert.IsTrue(controller.Stages.Count == 3);
      Assert.IsTrue(controller.EventQueue.Count == 0);
    }

    [Test]
    public void Start_GivenDefaultController_ExpectOneEventInEventQueue()
    {
      //Arrange
      var controller = new TrafficMonitor { SystemTime = DateTime.Now };

      //Act
      controller.Start();

      //Assert
      Assert.IsTrue(controller.EventQueue.Count == 1);
    }
  }
}