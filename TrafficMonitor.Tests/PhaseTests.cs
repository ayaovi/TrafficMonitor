using NUnit.Framework;

namespace TrafficMonitor.Tests
{
  [TestFixture]
  class PhaseTests
  {
    [TestCase(10, TestName = "EastEast")]
    [TestCase(2, TestName = "NorthEast")]
    [TestCase(3, TestName = "SouthEast")]
    public void DirectionUponCreation_GivenDirectionsArgument_ExpectSame(Direction direction)
    {
      //Arrange
      var phase = new Phase(direction);

      //Act && Assert
      Assert.IsTrue(phase.Direction == direction);
      Assert.IsTrue(phase.PhaseName == (PhaseName)direction);
    }

    [TestCase(Direction.EastEast, TestName = "EastEast")]
    [TestCase(Direction.NorthEast, TestName = "NorthEast")]
    [TestCase(Direction.SouthEast, TestName = "SouthEast")]
    public void IsActive_UponCreation_ShouldBeFalse(Direction direction)
    {
      //Arrange && Act && Assert
      Assert.IsTrue(new Phase(direction).IsActive == false);
    }

    [TestCase(10, TestName = "EastEast")]
    [TestCase(2, TestName = "NorthEast")]
    [TestCase(3, TestName = "SouthEast")]
    public void DirectionsUponCreation_GivenPhaseNameArgument_ExpectResult(PhaseName phaseName)
    {
      //Arrange
      var phase = new Phase(phaseName);

      //Act && Assert
      Assert.IsTrue(phase.Direction == (Direction)phaseName);
      Assert.IsTrue(phase.PhaseName == phaseName);
    }
  }
}