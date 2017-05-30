using System;
using System.Linq;
using NUnit.Framework;

namespace TrafficMonitor.Tests
{
  [TestFixture]
  class StateTests
  {
    [TestCase(-1, TestName = "State with -1 light.")]
    [TestCase(0, TestName = "State with 0 light.")]
    public void State_GivenInvalidNumberOfLight_ExpectException(int numberOfLight)
    {
      //Arrange && Act
      var exception = Assert.Throws<Exception>(() => { new State(numberOfLight); });
      //Assert
      Assert.IsTrue(exception.Message == $"Invalid Number Of Lights ({numberOfLight}). State Needs At Least One Light.");
    }


    [TestCase(1, TestName = "State with 1 light.")]
    [TestCase(2, TestName = "State with 2 light.")]
    [TestCase(3, TestName = "State with 3 light.")]
    [TestCase(4, TestName = "State with 4 light.")]
    public void Lights_GivenArgument_ExpectCorrespondingNumberOfLights(int value)
    {
      //Arrange && Act && Assert
      Assert.IsTrue(new State(value).Lights.Count() == value);
    }
  }
}