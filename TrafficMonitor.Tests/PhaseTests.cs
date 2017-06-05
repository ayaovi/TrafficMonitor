using System.Collections.Generic;
using NUnit.Framework;

namespace TrafficMonitor.Tests
{
  [TestFixture]
  class PhaseTests
  {
    [TestCase(new[] { Direction.EastEast }, TestName = "EastEast")]
    [TestCase(new[] { Direction.NorthEast }, TestName = "NorthEast")]
    [TestCase(new[] { Direction.SouthEast }, TestName = "SouthEast")]
    public void DirectionUponCreation_GivenListOfDirectionsArgument_ExpectSame(IList<Direction> direction)
    {
      //Arrange && Act && Assert
      Assert.IsTrue(new Phase(direction).Directions.Count == direction.Count);
    }

    [TestCase(new[] { Direction.EastEast }, TestName = "EastEast")]
    [TestCase(new[] { Direction.NorthEast }, TestName = "NorthEast")]
    [TestCase(new[] { Direction.SouthEast }, TestName = "SouthEast")]
    public void IsActive_UponCreation_ShouldBeFalse(IList<Direction> direction)
    {
      //Arrange && Act && Assert
      Assert.IsTrue(new Phase(direction).IsActive == false);
    }

    [Test]
    public void DirectionsUponCreation_GivenNameArgument_ExpectResult()
    {
      //Arrange && Act && Assert
      Assert.IsTrue(new Phase('A').Directions.Count == 2);
    }
  }
}