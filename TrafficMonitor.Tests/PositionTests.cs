using System;
using NUnit.Framework;

namespace TrafficMonitor.Tests
{
  [TestFixture]
  class PositionTests
  {
    [Test]
    public void Position_GivenInvalidValue_ExpectInvalidPositionException()
    {
      //Arrange && Act
      var exception = Assert.Throws<Exception>(() => { new Position(5); });
      //Assert
      Assert.IsTrue(exception.Message == "Invalid Position Exception.");
    }

    [TestCase(0, TestName = "Position 0")]
    [TestCase(1, TestName = "Position 1")]
    [TestCase(2, TestName = "Position 2")]
    [TestCase(3, TestName = "Position 3")]
    public void Position_GivenValidValue_ExpectPass(int value)
    {
      //Arrange && Act && Assert
      Assert.IsTrue(new Position(value).Value == value);
    }

    [TestCase(0, TestName = "Position 0")]
    [TestCase(1, TestName = "Position 1")]
    [TestCase(2, TestName = "Position 2")]
    [TestCase(3, TestName = "Position 3")]
    public void PositionEquality(int value)
    {
      //Arrange && Act && Assert
      Assert.IsTrue(new Position(value) == new Position(value));
    }

    [TestCase(0, 1, TestName = "Position 0")]
    [TestCase(1, 2, TestName = "Position 1")]
    [TestCase(2, 3, TestName = "Position 2")]
    [TestCase(3, 0, TestName = "Position 3")]
    public void PositionInequality(int value1, int value2)
    {
      //Arrange && Act && Assert
      Assert.IsTrue(new Position(value1) != new Position(value2));
    }
  }
}
