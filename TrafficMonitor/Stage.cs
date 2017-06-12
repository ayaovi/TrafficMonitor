using System.Collections.Generic;
using System.Linq;

namespace TrafficMonitor
{
  public class Stage
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
          Phases.Add(new Phase(PhaseName.A));
          Phases.Add(new Phase(PhaseName.B));
          break;
        case 2:
          Phases.Add(new Phase(PhaseName.C));
          Phases.Add(new Phase(PhaseName.D));
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
        if (phase.Direction.ToString().StartsWith("North")) Lights[0].Colour = Colour.Green;
        else if (phase.Direction.ToString().StartsWith("East")) Lights[1].Colour = Colour.Green;
        else if (phase.Direction.ToString().StartsWith("West")) Lights[2].Colour = Colour.Green;
        else if (phase.Direction.ToString().StartsWith("South")) Lights[3].Colour = Colour.Green;
      }
      IsActive = true;
    }
  }
}