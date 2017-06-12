using System.Linq;
using NUnit.Framework;

namespace TrafficMonitor.Tests
{
  [TestFixture]
  class StageTests
  {
    [Test]
    public void NumberOfLights_GivenDefaultStage_ExpectEight()
    {
      //Arrange && Act && Assert
      Assert.IsTrue(new Stage().Lights.Count == 4);
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

      //Act
      stage.Activate();

      //Assert
      Assert.IsTrue(stage.Lights.All(light => light.Colour == Colour.Red));
      Assert.IsTrue(stage.IsActive);
    }

    [Test]
    public void Activate_GivenStateOne_ExpectOnlyLightsZeroAndThreeBeGreen()
    {
      //Arrange
      var stage = new Stage(1);
      
      //Act
      stage.Activate();

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
      var stage = new Stage(2);

      //Act
      stage.Activate();

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