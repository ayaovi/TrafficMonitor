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
    public IList<TimeSpan> Duration { get; set; }

    public Stage()
    {
      //Lights = Enumerable.Range(0, 4).Select(i => new Light(Colour.Red, new Position(i))).ToList();
      Lights = new List<Light>();
      Phases = new List<Phase>();
      Duration = new List<TimeSpan> { new TimeSpan(3) };
    }

    public Stage(int number) : this()
    {
      switch (number)
      {
        case 1:
          Phases.Add(new Phase(PhaseName.A));
          Phases.Add(new Phase(PhaseName.B));
          Duration = new List<TimeSpan> { new TimeSpan(15), new TimeSpan(5) };
          break;
        case 2:
          Phases.Add(new Phase(PhaseName.C));
          Phases.Add(new Phase(PhaseName.D));
          Duration = new List<TimeSpan> { new TimeSpan(15), new TimeSpan(5) };
          break;
      }
    }

    public TrafficEvent Activate(DateTime startTime)
    {
      StartTime = startTime;
      IsActive = true;
      return Phases.Count == 0 ? new TrafficEvent(StartTime.Add(Duration[0]), Next.Duration[0], Next, stage => stage.Activate(StartTime.Add(Duration[0]))) : GoGreen(StartTime);
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

    public TrafficEvent GoGreen(DateTime time)
    {
      if (Phases.Count == 0 || !IsActive || time < StartTime) return null;
      {
        _changeColour(Colour.Green);
        return new TrafficEvent(time.Add(Duration[0]), Duration[1], this, stage => stage.GoYellow(StartTime.Add(Duration[0])));
      }
    }

    public TrafficEvent GoYellow(DateTime time)
    {
      if (Phases.Count == 0 || !IsActive || time < StartTime) return null;
      {
        _changeColour(Colour.Yellow);
        return new TrafficEvent(time.Add(Duration[1]), Next.Duration[0], Next, stage => stage.Activate(StartTime.Add(Duration[0] + Duration[1])));
      }
    }

    private void _changeColour(Colour colour)
    {
      foreach (var light in Lights)
      {
        light.Colour = Colour.Red;
      }

      foreach (var phase in Phases)
      {
        if (phase.PhaseName == PhaseName.A) Lights[0].Colour = colour;
        else if (phase.PhaseName == PhaseName.C) Lights[1].Colour = colour;
        else if (phase.PhaseName == PhaseName.D) Lights[2].Colour = colour;
        else if (phase.PhaseName == PhaseName.B) Lights[3].Colour = colour;
      }
    }
  }
}