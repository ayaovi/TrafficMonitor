using System;
using System.Collections.Generic;
using System.Linq;

namespace TrafficMonitor
{
  public class Stage
  {
    public IList<Light> Lights { get; set; }
    public IList<Phase> Phases { get; }
    public bool IsActive { get; set; }
    public Stage Next { get; set; }
    public DateTime StartTime { get; set; }

    public Stage()
    {
      //Lights = Enumerable.Range(0, 4).Select(i => new Light(Colour.Red, new Position(i))).ToList();
      Lights = new List<Light>();
      Phases = new List<Phase>();
    }

    public Stage(int number) : this()
    {
      switch (number)
      {
        case 1:
          Phases.Add(new Phase(PhaseName.A));
          Phases.Add(new Phase(PhaseName.B));
          break;
        case 2:
          Phases.Add(new Phase(PhaseName.C));
          Phases.Add(new Phase(PhaseName.D));
          break;
      }
    }

    public void Activate(DateTime startTime)
    {
      StartTime = startTime;
      foreach (var light in Lights)
      {
        light.Colour = Colour.Red;
      }

      foreach (var phase in Phases)
      {
        if (phase.PhaseName == PhaseName.A) Lights[0].Colour = Colour.Green;
        else if (phase.PhaseName == PhaseName.C) Lights[1].Colour = Colour.Green;
        else if (phase.PhaseName == PhaseName.D) Lights[2].Colour = Colour.Green;
        else if (phase.PhaseName == PhaseName.B) Lights[3].Colour = Colour.Green;
      }
      IsActive = true;
    }

    public override bool Equals(object obj)
    {
      // Check for null values and compare run-startTime types.
      if (obj == null || GetType() != obj.GetType())
        return false;

      var stage = (Stage)obj;
      return Lights.Count == stage.Lights.Count && Phases.Count == stage.Phases.Count &&
      Lights.Select((light, i) => light.Equals(stage.Lights[i])).All(x => x) &&
      Phases.Select((phase, i) => phase.Equals(stage.Phases[i])).All(x => x);
    }
  }
}