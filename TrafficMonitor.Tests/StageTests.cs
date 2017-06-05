using System.Collections.Generic;
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

    [Test]
    public void Phases_GivenStageOne_ExpectTwo()
    {
      //Arrange && Act && Assert
      Assert.IsTrue(new Stage(1).Phases.Count == 2);
    }

    [Test]
    public void Activate_GivenStateOne_ExpectLightsZeroAndThreeBeGreen()
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
  }

  internal class Stage
  {
    public IList<Light> Lights { get; }
    public IList<Phase> Phases { get; }
    public bool IsActive { get; set; }

    public Stage()
    {
      Lights = Enumerable.Range(0, 4).Select(i => new Light(Colour.Red, new Position(i))).ToList();
      Phases = new List<Phase>();
    }

    public Stage(int number) : this()
    {
      switch (number)
      {
        case 1:
          Phases.Add(new Phase('A'));
          Phases.Add(new Phase('B'));
          break;
      }
    }

    public void Activate()
    {
      foreach (var light in Lights)
      {
        light.Colour = Colour.Red;
      }

      foreach (var phase in Phases)
      {
        foreach (var direction in phase.Directions)
        {
          if (direction.ToString().StartsWith("North")) Lights[0].Colour = Colour.Green;
          else if (direction.ToString().StartsWith("East")) Lights[1].Colour = Colour.Green;
          else if (direction.ToString().StartsWith("West")) Lights[2].Colour = Colour.Green;
          else if (direction.ToString().StartsWith("South")) Lights[3].Colour = Colour.Green;
        }
      }
      IsActive = true;
    }
  }
}