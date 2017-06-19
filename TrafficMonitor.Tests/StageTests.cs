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
    public void Duration_GivenDefaultStage_ExpectThree()
    {
      //Arrange
      var stage = new Stage();

      //Arrange && Act && Assert
      Assert.IsTrue(stage.Duration.Count == 1);
      Assert.IsTrue(stage.Duration[0] == new TimeSpan(3));
    }


    [Test]
    public void GoGreen_GivenActivatedStageOne_ExpectLightsZeroAndThreeGreen()
    {
      //Arrange
      var stage = new Stage(1) { Lights = Enumerable.Range(0, 4).Select(i => new Light(Colour.Red, new Position(i))).ToList(), IsActive = true };

      //Act
      stage.GoGreen(DateTime.Now);

      //Assert
      Assert.IsTrue(stage.Lights[0].Colour == Colour.Green);
      Assert.IsTrue(stage.Lights[1].Colour == Colour.Red);
      Assert.IsTrue(stage.Lights[2].Colour == Colour.Red);
      Assert.IsTrue(stage.Lights[3].Colour == Colour.Green);
    }

    [Test]
    public void GoGreen_GivenDeactivatedStageOne_ExpectAllLightsRed()
    {
      //Arrange
      var stage = new Stage(1) { Lights = Enumerable.Range(0, 4).Select(i => new Light(Colour.Red, new Position(i))).ToList() };

      //Act
      stage.GoGreen(DateTime.Now);

      //Assert
      Assert.IsTrue(stage.Lights.All(light => light.Colour == Colour.Red));
    }

    [TestCase(true, TestName = "Activated")]
    [TestCase(true, TestName = "Deactivated")]
    public void GoGreen_GivenActivatedStageZero_ExpectALlLightsRed(bool activation)
    {
      //Arrange
      var stage = new Stage { Lights = Enumerable.Range(0, 4).Select(i => new Light(Colour.Red, new Position(i))).ToList(), IsActive = activation };

      //Act
      stage.GoGreen(DateTime.Now);

      //Assert
      Assert.IsTrue(stage.Lights.All(light => light.Colour == Colour.Red));
    }

    [TestCase(true, TestName = "Activated")]
    [TestCase(true, TestName = "Deactivated")]
    public void GoYellow_GivenActivatedStageZero_ExpectALlLightsRed(bool activation)
    {
      //Arrange
      var stage = new Stage { Lights = Enumerable.Range(0, 4).Select(i => new Light(Colour.Red, new Position(i))).ToList(), IsActive = activation };

      //Act
      stage.GoYellow(DateTime.Now);

      //Assert
      Assert.IsTrue(stage.Lights.All(light => light.Colour == Colour.Red));
    }


    [Test]
    public void GoYellow_GivenDeactivatedStageOne_ExpectAllLightsRed()
    {
      //Arrange
      var stage = new Stage(1) { Lights = Enumerable.Range(0, 4).Select(i => new Light(Colour.Red, new Position(i))).ToList() };

      //Act
      stage.GoYellow(DateTime.Now);

      //Assert
      Assert.IsTrue(stage.Lights.All(light => light.Colour == Colour.Red));
    }


    [Test]
    public void GoYellow_GivenActivatedStageOne_ExpectLightsZeroAndThreeBeYellow()
    {
      //Arrange
      var stage = new Stage(1) { Lights = Enumerable.Range(0, 4).Select(i => new Light(Colour.Red, new Position(i))).ToList(), IsActive = true };

      //Act
      stage.GoYellow(DateTime.Now);

      //Assert
      Assert.IsTrue(stage.Lights[0].Colour == Colour.Yellow);
      Assert.IsTrue(stage.Lights[1].Colour == Colour.Red);
      Assert.IsTrue(stage.Lights[2].Colour == Colour.Red);
      Assert.IsTrue(stage.Lights[3].Colour == Colour.Yellow);
    }


    [Test]
    public void GoYellow_GivenActivatedStageOne_ExpectEventToActivateStageThree()
    {
      //Arrange
      var stage = new Stage(1) { Lights = Enumerable.Range(0, 4).Select(i => new Light(Colour.Red, new Position(i))).ToList(), IsActive = true };

      //Act
      var @event = stage.GoYellow(DateTime.Now);

      //Assert
      Assert.IsTrue(@event.GetType() == typeof(TrafficEvent));
    }


    [TestCase(1, TestName = "StageOne")]
    [TestCase(2, TestName = "StageTwo")]
    public void Duration_GivenNonIdleStages_ExpectFithteenAndFive(int index)
    {
      //Arrange
      var stage = new Stage(index);

      //Arrange && Act && Assert
      Assert.IsTrue(stage.Duration.Count == 2);
      Assert.IsTrue(stage.Duration[0] == new TimeSpan(15));
      Assert.IsTrue(stage.Duration[1] == new TimeSpan(5));
    }

    [Test]
    public void NumberOfLights_GivenThreeLightsArgument_ExpectThree()
    {
      //Arrange
      var lights = Enumerable.Range(0, 3).Select(i => new Light(Colour.Red, new Position(i))).ToList();
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
        Lights = Enumerable.Range(0, 4).Select(i => new Light(Colour.Red, new Position(i))).ToList()
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
        Lights = Enumerable.Range(0, 4).Select(i => new Light(Colour.Red, new Position(i))).ToList()
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
    public void Activate_GivenStageZero_ExpectEventToActivateStageOne()
    {
      //Arrange
      var lights = Enumerable.Range(0, 4).Select(i => new Light(Colour.Red, new Position(i))).ToList();
      var stages = Enumerable.Range(0, 3).Select(i => new Stage(i) { Lights = lights }).ToList();

      stages[0].Next = stages[1];
      stages[1].Next = stages[2];
      stages[2].Next = stages[0];

      //Act
      var @event = stages[0].Activate(DateTime.Now);

      //Assert
      Assert.IsTrue(@event.Stage.Equals(stages[1]));
      Assert.IsTrue(@event.Time == stages[0].StartTime.Add(stages[0].Duration[0]));
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