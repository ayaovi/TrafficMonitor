using System;
using System.Linq;
using NUnit.Framework;

namespace TrafficMonitor.Tests
{
  [TestFixture]
  class StageTests
  {
    [Test]
    public void NumberOfLights_GivenDefaultStage_ExpectFour()
    {
      //Arrange && Act && Assert
      Assert.IsTrue(new Stage().Lights.Count == 0);
    }

    [Test]
    public void NumberOfLights_GivenThreeLightsArgument_ExpectThree()
    {
      //Arrange
      var lights = new[]
      {
        new Light(Colour.Red, new Position(0)),
        new Light(Colour.Red, new Position(1)),
        new Light(Colour.Red, new Position(2))
      };
      var stage = new Stage
      {
        Lights = lights,
        Next = new Stage(1) { Lights = lights }
      };

      //Act && Assert
      Assert.IsTrue(stage.Lights.Count == 3);
      Assert.IsTrue(stage.Next.Equals(new Stage(1) { Lights = lights }));
    }

    [Test]
    public void AllLights_GivenDefaultStage_ExpectRed()
    {
      //Arrange && Act && Assert
      Assert.IsTrue(new Stage().Lights.All(light => light.Colour == Colour.Red));
    }

    [Test]
    public void IsActive_GivenDefaultStage_ExpectFalse()
    {
      //Arrange && Act && Assert
      Assert.IsFalse(new Stage().IsActive);
    }

    [Test]
    public void NoPhase_GivenDefaultStage()
    {
      //Arrange && Act && Assert
      Assert.IsTrue(new Stage().Phases.Count == 0);
    }

    [TestCase(1, 2)]
    [TestCase(2, 2)]
    public void Phases_GivenCertainStage_ExpectAppropriateNumberOfPhases(int stageIndex, int numberOfPhases)
    {
      //Arrange && Act && Assert
      Assert.IsTrue(new Stage(stageIndex).Phases.Count == numberOfPhases);
    }

    [Test]
    public void Activate_GivenStateZero_ExpectAllLightShouldBeRed()
    {
      //Arrange
      var stage = new Stage(0);
      var startTime = DateTime.Now;

      //Act
      stage.Activate(startTime);

      //Assert
      Assert.IsTrue(stage.StartTime == startTime);
      Assert.IsTrue(stage.Lights.All(light => light.Colour == Colour.Red));
      Assert.IsTrue(stage.IsActive);
    }

    [Test]
    public void Activate_GivenStateOne_ExpectOnlyLightsZeroAndThreeBeGreen()
    {
      //Arrange
      var stage = new Stage(1)
      {
        Lights =
          new[]
          {
            new Light(Colour.Red, new Position(0)), new Light(Colour.Red, new Position(1)),
            new Light(Colour.Red, new Position(2)), new Light(Colour.Red, new Position(3))
          }
      };

      //Act
      stage.Activate(DateTime.Now);

      //Assert
      Assert.IsTrue(stage.Lights[0].Colour == Colour.Green);
      Assert.IsTrue(stage.Lights[1].Colour == Colour.Red);
      Assert.IsTrue(stage.Lights[2].Colour == Colour.Red);
      Assert.IsTrue(stage.Lights[3].Colour == Colour.Green);
      Assert.IsTrue(stage.IsActive);
    }

    [Test]
    public void Activate_GivenStateTwo_ExpectOnlyLightOneAndTwoBeGreen()
    {
      //Arrange
      var stage = new Stage(2)
      {
        Lights =
          new[]
          {
            new Light(Colour.Red, new Position(0)), new Light(Colour.Red, new Position(1)),
            new Light(Colour.Red, new Position(2)), new Light(Colour.Red, new Position(3))
          }
      };

      //Act
      stage.Activate(DateTime.Now);

      //Assert
      Assert.IsTrue(stage.Lights[0].Colour == Colour.Red);
      Assert.IsTrue(stage.Lights[1].Colour == Colour.Green);
      Assert.IsTrue(stage.Lights[2].Colour == Colour.Green);
      Assert.IsTrue(stage.Lights[3].Colour == Colour.Red);
      Assert.IsTrue(stage.IsActive);
    }

    [Test]
    public void Equals_GivenSameStage_ExpectTrue()
    {
      //Arrange && Act && Assert
      Assert.IsTrue(new Stage(1).Equals(new Stage(1)));
    }

    [Test]
    public void Equals_GivenDifferentStage_ExpectFalse()
    {
      //Arrange && Act && Assert
      Assert.IsFalse(new Stage(0).Equals(new Stage(2)));
    }
  }
}