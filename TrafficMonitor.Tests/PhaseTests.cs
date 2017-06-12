using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace TrafficMonitor.Tests
{
  [TestFixture]
  class PhaseTests
  {
    [TestCase(PhaseName.A, new[] {Direction.NorthWest, Direction.NorthEast, Direction.NorthNorth}, TestName = "From_North")]
    [TestCase(PhaseName.B, new[] { Direction.SouthEast, Direction.SouthWest, Direction.SouthSouth }, TestName = "From_South")]
    [TestCase(PhaseName.C, new[] { Direction.WestSouth, Direction.WestWest, Direction.WestNorth }, TestName = "From_West")]
    [TestCase(PhaseName.D, new[] { Direction.EastEast, Direction.EastNorth, Direction.EastSouth }, TestName = "From_East")]
    public void DirectionUponCreation_GivenDirectionsArgument_ExpectSame(PhaseName phaseName, IEnumerable<Direction> directions)
    {
      //Arrange
      var phase = new Phase(phaseName);

      //Act && Assert
      Assert.IsTrue(phase.Directions.All(direction => directions.Contains(direction)));
      Assert.IsTrue(phase.PhaseName == phaseName);
    }

    [TestCase(PhaseName.A, TestName = "From_North")]
    [TestCase(PhaseName.B, TestName = "From_South")]
    [TestCase(PhaseName.C, TestName = "From_West")]
    [TestCase(PhaseName.D, TestName = "From_East")]
    public void IsActive_UponCreation_ShouldBeFalse(PhaseName phaseName)
    {
      //Arrange && Act && Assert
      Assert.IsTrue(new Phase(phaseName).IsActive == false);
    }

    [Test]
    public void Equals_GivenSamePhase_ExpectTrue()
    {
      //Arrange && Act && Assert
      Assert.IsTrue(new Phase(PhaseName.A).Equals(new Phase(PhaseName.A)));
    }

    [Test]
    public void Equals_GivenDifferentPhase_ExpectFalse()
    {
      //Arrange && Act && Assert
      Assert.IsFalse(new Phase(PhaseName.A).Equals(new Phase(PhaseName.B)));
    }
  }
}