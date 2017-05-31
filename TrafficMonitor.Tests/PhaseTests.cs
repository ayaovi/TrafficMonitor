using NUnit.Framework;

namespace TrafficMonitor.Tests
{
  [TestFixture]
  class PhaseTests
  {
    [TestCase(Direction.EastEast, TestName = "EastEast")]
    [TestCase(Direction.NorthEast, TestName = "NorthEast")]
    [TestCase(Direction.SouthEast, TestName = "SouthEast")]
    public void DirectionUponCreation_GivenArgument_ExpectSame(Direction direction)
    {
      //Arrange && Act && Assert
      Assert.IsTrue(new Phase(direction).Direction == direction);
    }

    [TestCase(Direction.EastEast, TestName = "EastEast")]
    [TestCase(Direction.NorthEast, TestName = "NorthEast")]
    [TestCase(Direction.SouthEast, TestName = "SouthEast")]
    public void IsActive_UponCreation_ShouldBeFalse(Direction direction)
    {
      //Arrange && Act && Assert
      Assert.IsTrue(new Phase(direction).IsActive == false);
    } 
  }
}
